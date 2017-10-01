using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool isTypingNumber = false;

        enum Pheptoan { None, Cong, Tru, Nhan, Chia };
        Pheptoan pheptoan;

        double Nho;



        private void Nhapso(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Nhapso(btn.Text);

        }
        private void Nhapso(string so)
        {
            if (isTypingNumber)
            {
                // Xoá số 0 ở đầu số
                if (lblHienThi.Text == "0")
                    lblHienThi.Text = "";

                lblHienThi.Text += so;
                }
               
            else
            {

                lblHienThi.Text = so;
                isTypingNumber = true;
            }


        }
        private void NhapPhepToan(object sender, EventArgs e)
        { 
            if (Nho !=0)
            TinhKetQua();
            Button btn = (Button)sender;
            switch (btn.Text)
            {
                case "+": pheptoan = Pheptoan.Cong; break;
                case "-": pheptoan = Pheptoan.Tru; break;
                case "*": pheptoan = Pheptoan.Nhan; break;
                case "/": pheptoan = Pheptoan.Chia; break;
            }
            Nho = double.Parse(lblHienThi.Text);
            isTypingNumber = false;
        }
        private void TinhKetQua()
        {
            //tinh toan dua tren : nho, phep toan, lblHienThi.Text
            double tam = double.Parse(lblHienThi.Text);
            double ketqua = 0.0;
            switch (pheptoan)
            {
                case Pheptoan.Cong: ketqua = Nho + tam; break;
                case Pheptoan.Tru: ketqua = Nho - tam; break;
                case Pheptoan.Nhan: ketqua = Nho * tam; break;
                case Pheptoan.Chia: ketqua = Nho / tam; break;
            }

            //gan ket qua tinh duoc len lblHienThi
            lblHienThi.Text = ketqua.ToString();
        }

        private void btnbang_Click(object sender, EventArgs e)
        {
            TinhKetQua();
            isTypingNumber = false;
            Nho = 0;
            pheptoan = Pheptoan.None;

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    Nhapso("" + e.KeyChar);
                    break;
           }
        }
            private void btnCan_Click(object sender, EventArgs e)
        {
          lblHienThi.Text = (Math.Sqrt(Double.Parse(lblHienThi.Text))).ToString();
        }

        private void btnDoiDau_Click(object sender, EventArgs e)
        {
         lblHienThi.Text = (-1 * (double.Parse(lblHienThi.Text))).ToString();
        }

        private void btnPhanTram_Click(object sender, EventArgs e)
        {
            lblHienThi.Text = ((double.Parse(lblHienThi.Text) / 100)).ToString();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (lblHienThi.Text.Length > 0)
                lblHienThi.Text = lblHienThi.Text.Remove(lblHienThi.Text.Length - 1, 1);
            if (lblHienThi.Text =="")
            { 
                lblHienThi.Text = "0";
            }
        }

        private void btnNho_Click(object sender, EventArgs e)
        {
            Nho = 0;
            lblHienThi.Text = "0";
        }

        private void btncham_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã tồn tại dấu chấm trong lblHienThi.Text hay chưa
            if (lblHienThi.Text.Contains("."))
            {
                if (lblHienThi.Text == "0.")
                {
                    lblHienThi.Text = "";
                    Nhapso("0.");
                }
                return;
            }

            lblHienThi.Text += ".";
        }

      

       

    
        }
        }
    
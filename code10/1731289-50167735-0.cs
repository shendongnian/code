        private void btn_LoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            if (fdlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                System.IO.StreamReader(fdlg.FileName);
                string[] lines = sr.ReadToEnd().Split('\n');
                PrintText(tb_SerialNo, lines[0]);
                PrintText(tb_TypeNo , lines[1]);
                PrintText(tb_TestEngineer, lines[2]);
                PrintText(tb_Date, lines[3]);
                PrintText(tb_Test1, lines[4]);
                PrintText(tb_Test2, lines[5]);
            }
        }
        private void PrintText(TextBox control, string line)
        {
            var splitline = line.Split('=');
            control.Text = splitline[1];
        }

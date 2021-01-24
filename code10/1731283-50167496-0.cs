     private void btn_LoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            if (fdlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                System.IO.StreamReader(fdlg.FileName);
    
                string[] lines = sr.ReadToEnd().Split('\n');
                Console.WriteLine(lines[0]); //Here it will written "Serial Number = 1"
                // you need to store 1 in tb_SerialNo.Text, so split lines[0] with =
    
                tb_SerialNo.Text = lines[0];
                tb_TypeNo.Text = lines[1];
                tb_TestEngineer.Text = lines[2];
                tb_Date.Text = lines[3];
                tb_Test1.Text = lines[4];
                tb_Test2.Text = lines[5];
            }  
    
        }

     private void btn_LoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            if (fdlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                System.IO.StreamReader(fdlg.FileName);
    
                string[] lines = sr.ReadToEnd().Split('\n'); //To make your code more readable, you can use "Environment.NewLine" instead of '\n'
                Console.WriteLine(lines[0]); //Here it will give "Serial Number = 1"
                // you need to store 1 in tb_SerialNo.Text, so split lines[0] with =
               //Have you tried with this.
                string[] splitWithEqualTo = lines[0].Split('=');
                tb_SerialNo.Text = splitWithEqualTo [1];
              //Similar kind of logic you can apply for other text boxes.
            }  
        }

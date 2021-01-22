            `private void button1_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "This PC\\Documents";
            openFileDialog1.Filter = "All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Open a file with code";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string exeCode = string.Empty;
                using (BinaryReader br = new BinaryReader(File.OpenRead(openFileDialog1.FileName))) //Sets a new integer to the BinaryReader
                {
                    br.BaseStream.Seek(0x4D, SeekOrigin.Begin); //The seek is starting from 0x4D
                    exeCode = Encoding.UTF8.GetString(br.ReadBytes(1000000000)); //Reads as many bytes as it can from the beginning of the .exe file
                }
                using (BinaryReader br = new BinaryReader(File.OpenRead(openFileDialog1.FileName)))
                    br.Close(); //Closes the BinaryReader. Without it, opening the file with any other command will result the error "This file is being used by another process".
                richTextBox1.Text = exeCode;
            }
        }`

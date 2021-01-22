            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "All Files (*.*)|*.*";
            save.Title = "Save Your Changes";
            save.InitialDirectory = "This PC\\Documents";
            save.FilterIndex = 1;
            if (save.ShowDialog() == DialogResult.OK)
            {
                using (BinaryWriter bw = new BinaryWriter(File.OpenWrite(save.FileName))) //Sets a new integer to the BinaryReader
                {
                    bw.BaseStream.Seek(0x4D, SeekOrigin.Begin); //The seek is starting from 0x4D
                    bw.Write(richTextBox1.Text);
                }
            }
        }`

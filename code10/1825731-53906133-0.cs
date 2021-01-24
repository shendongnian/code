    if(result == DialogResult.OK) 
        {
            openFileName = openFileDialog1.FileName;
            try
            {
                // Output the requested file in richTextBox1.
                Stream s = openFileDialog1.OpenFile();
                richTextBox1.LoadFile(s, RichTextBoxStreamType.RichText);
                s.Close();    
            
                fileOpened = true;
            } 
            catch(Exception exp)
            {
                MessageBox.Show("An error occurred while attempting to load the file. The error is:" 
                                + System.Environment.NewLine + exp.ToString() + System.Environment.NewLine);
                fileOpened = false;
            }

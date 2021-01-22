            if (richTextBox1.Text != "")
            {
                if (DialogResult.Yes == MessageBox.Show(("Do you want to save changes to Untiteled"), "Notepad", MessageBoxButtons.YesNoCancel))
                {
                    saveFileDialog1.ShowDialog();
                    FileStream fs = new FileStream(saveFileDialog1.FileName + ".txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(richTextBox1.Text);
                    sw.Close();
                    fs.Close();
                
                }
                else if (DialogResult.No == MessageBox.Show(("Do you want to save changes to Untiteled"), "Notepad", MessageBoxButtons.YesNoCancel))
                {
                    richTextBox1.Clear();
                }
                else if (DialogResult.Cancel == MessageBox.Show(("Do you want to save changes to Untiteled"), "Notepad", MessageBoxButtons.YesNoCancel))
                {
                    
                
                     ***//when i click on cancel button...the dialogbox should be close??????????????????????***
                }
                
            }
            else
            { 
                richTextBox1.Clear(); 
            }
            
        }

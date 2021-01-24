    private void Load_File_Contents_Click(object sender, EventArgs e)
        {
            try
            {
                //Below code will read the file and set the rich textbox with the contents of file
                string filePath = @"C:\New folder\file1.txt";
                richTextBox1.Text = File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private void ReplaceAndWriteToFile_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = @"C:\New folder\file1.txt";
                //Find the "find" text from the richtextbox and replace it with the "replace" text
                string find = txtFind.Text.Trim(); //txtFind is textbox and will have the text that we want to find and replace
                string replace = txtReplace.Text.Trim(); //txtReplace is text and it will replace the find text with Replace text
                string newText = richTextBox1.Text.Replace(find, replace);
                richTextBox1.Text = newText;
                //Write the new contents of rich text box to file
                File.WriteAllText(filePath, richTextBox1.Text.Trim());
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

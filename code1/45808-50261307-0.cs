        private void btnSearch_Click(object sender, EventArgs e)
        {
            string userinput = txtInput.Text;
            string sourceFolder = @"C:\mytestDir\";
            string searchWord = txtInput.Text + ".pdf";
            string filePresentCK = sourceFolder + searchWord;
            if (File.Exists(filePresentCK))
                {
                   
                    pdfViewer1.LoadFromFile(sourceFolder+searchWord);
                }
                else if(! File.Exists(filePresentCK))
                {
                    MessageBox.Show("Unable to Find file :" + searchWord);
                }
            
            txtInput.Clear();
           
        }// end of btnSearch method 

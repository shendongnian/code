        public void PDF_TEXT()
        {
            richTextBox1.Text =  string.Empty;
            ReadPdfFile(@"C:\Myfile.pdf");  //read pdf file from location
        }
        public void ReadPdfFile(string fileName)
        {
      
     string strText = string.Empty;
     StringBuilder text = new StringBuilder();
       try
        {
        PdfReader reader = new PdfReader((string)fileName);
        if (File.Exists(fileName))
        {
        PdfReader pdfReader = new PdfReader(fileName);
       for (int page = 1; page <= pdfReader.NumberOfPages; page++)
          {
     ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
     string currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);
                     
              text.Append(currentText);
                    }
                    pdfReader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            richTextBox1.Text = text.ToString();
        }
        private void Save_TextFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            DialogResult messageResult = MessageBox.Show("Save this file into Text?", "Text File", MessageBoxButtons.OKCancel);
            if (messageResult == DialogResult.Cancel)
            {
                
            }
            else
            {
                sfd.Title = "Save As Textfile";
                sfd.InitialDirectory = @"C:\";
                sfd.Filter = "TextDocuments|*.txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (richTextBox1.Text != "")
                    {
                        richTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.PlainText);
                        richTextBox1.Text = "";
                        MessageBox.Show("Text Saved Succesfully", "Text File");
                    }
                    else
                    {
                        MessageBox.Show("Please Upload Your Pdf", "Text File",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                    }
                }
            }
        }

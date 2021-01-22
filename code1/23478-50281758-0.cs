        private string password = "@d45235fewf";
        private const string pdfFile = @"C:\Temp\Old.pdf";
        private const string pdfFileOut = @"C:\Temp\New.pdf";
    public void DecryptPdf()
    {
            //Set reader properties and password
            ReaderProperties rp = new ReaderProperties();
            rp.SetPassword(new System.Text.UTF8Encoding().GetBytes(password));
            //Read the PDF and write to new pdf
            using (PdfReader reader = new PdfReader(pdfFile, rp))
            {
                reader.SetUnethicalReading(true);
                PdfDocument pdf = new PdfDocument(reader, new PdfWriter(pdfFileOut));
            }               
    } 

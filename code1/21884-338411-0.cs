    string filePath = @"c:\file.pdf";
    
    using (PdfDocument ipdf = PdfReader.Open(filePath, PdfDocumentOpenMode.ReadOnly))
    {
        int i = 1;
        foreach (PdfPage page in ipdf.Pages)
        {
            using (PdfDocument opdf = new PdfDocument())
            {
                opdf.Version = ipdf.Version;
                opdf.AddPage(page);
    
                opdf.Save("page " + i++ + ".pdf");
            }
        }
    }

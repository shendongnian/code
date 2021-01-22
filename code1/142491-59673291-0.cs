    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.parser;
    //create a list of pdf pages
    var pages = new List<PdfPage>();
    
    //load the pdf into the reader. NOTE: path can also be replaced with a byte array
    using (PdfReader reader = new PdfReader(path))
    {
        //loop all the pages and extract the text
        for (int i = 1; i <= reader.NumberOfPages; i++)
        {
            pages.Add(new PdfPage()
            {
               content = PdfTextExtractor.GetTextFromPage(reader, i)
            });
        }
    }

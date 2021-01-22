    public ActionResult GeneratePdf()
    {
         Document pdfDocument = new Document();
         MemoryStream stream = new MemoryStream();
         PdfWriter.GetInstance(pdfDocument,stream); 
         //add some code to generate your pdf content
         pdfDocument.Close();
         return new FileResult(stream,"application/pdf");
    }

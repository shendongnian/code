    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult PrintPdf(SubmitReport model)
    {
        // other stuff
    
        byte[] pdfStream;
    
        using (var stream = new MemoryStream())
        {
            // fill stream content from other source
            stream = PdfGenerator.PayrollConfirmPdf(pdfModel);
            pdfStream = stream.ToArray();
        }
    
        // TODO: what is the name of the pdf file?
        var filename = string.Concat("PayrollConfirmation", DateTime.Now.ToString("yyyyMMddHHmmss"), ".pdf");
    
        // FileContentResult
        return File(pdfStream, "application/pdf", filename);            
    }

    public ActionResult Pdf(string url, string filename)
    {
        MemoryStream memory = new MemoryStream();
        PdfDocument document = new PdfDocument() { Url = url };
        PdfOutput output = new PdfOutput() { OutputStream = memory };
        PdfConvert.ConvertHtmlToPdf(document, output);
        memory.Position = 0;
        return File(memory, "application/pdf", Server.UrlEncode(filename));
    }

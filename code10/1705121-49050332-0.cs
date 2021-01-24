    public ActionResult Dashboard(HttpPostedFileBase file,string typeofmodel)
    {
       var htmlToPdf = new HtmlToPdfConverter();
        var stream = new MemoryStream();
        var pdfContentType = "application/pdf";
        // processing the stream.
        BinaryReader b = new BinaryReader(File.InputStream);
        byte[] binData = b.ReadBytes(File.ContentLength);
        string html = System.Text.Encoding.UTF8.GetString(binData);
        stream.Write(htmlToPdf.GeneratePdf(html, null), 0, htmlToPdf.GeneratePdf(html, null).Length);
        return File(stream, pdfContentType, "Htmltopdf.pdf"); 
       
    }

    using iTextSharp.text;
    using iTextSharp.text.pdf;
    public FileStreamResult pdf()
    {
        MemoryStream workStream = new MemoryStream();
        Document document = new Document();
        PdfWriter.GetInstance(document, workStream).CloseStream = false;
        document.Open();
        document.Add(new Paragraph("Hello World"));
        document.Add(new Paragraph(DateTime.Now.ToString()));
        document.Close();
        byte[] byteInfo = workStream.ToArray();
        workStream.Write(byteInfo, 0, byteInfo.Length);
        workStream.Position = 0;
        return new FileStreamResult(workStream, "application/pdf");    
    }

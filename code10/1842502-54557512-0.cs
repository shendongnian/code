    public FileStreamResult pdf()
    {
        var workStream = new MemoryStream())
        using (var pdfWriter = new PdfWriter(workStream))
        {
            pdfWriter.SetCloseStream(false);
            using (var document = HtmlConverter.ConvertToDocument(html, pdfWriter))
            {
            }
        }
        workStream.Position = 0;
        return new FileStreamResult(workStream, "application/pdf");
    }

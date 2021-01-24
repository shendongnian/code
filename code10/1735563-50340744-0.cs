    public FileResult DownloadZipfile(string html) {
        
        byte[] rawDownload = PDFConverterUtils.PdfSharpConvert(html);
        
        MemoryStream memoryStream = new MemoryStream();
        ZipArchive archive = new ZipArchive(stream: memoryStream, mode: ZipArchiveMode.Create, leaveOpen: false);
        ZipArchiveEntry entry = archive.CreateEntry("MyPDF.pdf");
        using (Stream entryStream = entry.Open()) {
            entryStream.Write(rawDownload, 0, rawDownload.Length);
        }
        memoryStream.Position = 0;//reset memory stream position
        return new FileStreamResult(memoryStream, System.Net.Mime.MediaTypeNames.Application.Zip) {
            FileDownloadName = "test.zip" 
        };
    }

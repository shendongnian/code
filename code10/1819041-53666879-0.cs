    public ActionResult ByteConverter()
    {
        ApiClient api = new ApiClient("http://localhost:43674/ApiCore");
        var result = await api.GetAsync();
        var pdfData = result.Pdf;
        MemoryStream Stream = new MemoryStream(pdfData);
        Stream.Write(pdfData, 0 , pdfData.Length);
        Stream.Position = 0;
        return new FileStreamResult(Stream,"application/pdf");
    }

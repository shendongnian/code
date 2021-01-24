    public void Download(string file, string extension)
    {
        var container = cloudBlobClient.GetContainerReference("test");
        container.CreateIfNotExists();
        var blockBlob = container.GetBlockBlobReference(file + "." + fileExtension);
        blockBlob.FetchAttributes();
        var contentType = blockBlob.Properties.ContentType;   
        MemoryStream memStream = new MemoryStream();
        blockBlob.DownloadToStream(memStream);
        var response = HttpContext.Response;
        response.ContentType = contentType;
        response.AddHeader("Content-Disposition", "Attachment; filename=" + file + "." + fileExtension);
        response.AddHeader("Content-Length", blockBlob.Properties.Length.ToString());
        response.BinaryWrite(memStream.ToArray());
    }

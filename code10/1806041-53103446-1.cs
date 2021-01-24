    //Get file
    FileStream fs2 = File.OpenRead(FilePath);
    StreamContent streamContent2 = new StreamContent(fs);
    streamContent2.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data") {
        Name = string.Format("\"{0}\"", FileName),
        Filename = string.Format("\"{0}\"", FileName),
    };
    streamContent2.Headers.Add("Content-Type", "application/octet-stream");
    multipartContent.Add(streamContent2);

    const int bufferSize= 1024;
    var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
    foreach (var content in filesReadToProvider.Contents)
    {
        var stream = await content.ReadAsStreamAsync();
        using (StreamReader sr = new StreamReader(stream))
        {
            int bytesRead;
            char[] buffer = new char[bufferSize];
            while ((bytesRead = sr.ReadBlock(buffer, 0, bufferSize)) > 0)
            {
                  // Do something with the first <bytesRead> of buffer and
                  // not with <bufferSize> as <bytesRead> will contain the
                  // number of bytes actually read by the call to ReadBlock
            }
        }
    }

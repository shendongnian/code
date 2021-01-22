    using (var client = new WebClientWithResponse())
    {
        using (var stream = client.OpenWrite(myUrl))
        {
            // open a huge local file and send it
            using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                file.CopyTo(stream);
            }
        }
    
        // get response as an array of bytes. You'll need some encoding to convert to string, etc.
        var bytes = client.Response;
    }

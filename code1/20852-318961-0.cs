    var urls = new [] { "http://www.google.com", "http://www.yahoo.com", "http://www.live.com" };
    
    foreach (var url in urls)
    {
        WebRequest request = WebRequest.Create(url);
        using (Stream responseStream = request.GetResponse().GetResponseStream())
        using (Stream outputStream = new FileStream("file" + DateTime.Now.Ticks.ToString(), FileMode.Create, FileAccess.Write, FileShare.None))
        {
            const int chunkSize = 1024;
            byte[] buffer = new byte[chunkSize];
            int bytesRead;
            while ((bytesRead = responseStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                byte[] actual = new byte[bytesRead];
                Buffer.BlockCopy(buffer, 0, actual, 0, bytesRead);
                outputStream.Write(actual, 0, actual.Length);
            }
        }
        Thread.Sleep(1000);
    }

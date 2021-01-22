    var client = new System.Net.WebClient();
    byte[] buffer = client.DownloadData(url);
    using (var stream = new MemoryStream(buffer))
    {
        ... your code using the stream ...
    }

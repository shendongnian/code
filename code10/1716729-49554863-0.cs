    fs.Position = 0;
    byte[] bytes = new byte[fs.Length];
    fs.Read(bytes, 0, (int) fs.Length);
    ByteArrayContent content = new ByteArrayContent(bytes);
    content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
    content.Headers.ContentLength = fs.Length;
    var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5000/Home/Upload");
    request.Content = content;
    try
    {
        HttpResponseMessage response = await client.SendAsync(request);

    static HttpClient client;
    static object mutex = new object();
    static HttpClient Client
    {
        get
        {
            if (client == null)
            {
                lock (mutex)
                {
                    if (client == null)
                    {
                        client = new HttpClient();
                        client.DefaultRequestHeaders.Add("MIME-Version", "1.0");
                        client.DefaultRequestHeaders.Add("SOAPAction", "\"\"");
                        client.DefaultRequestHeaders.ConnectionClose = true;
                        client.DefaultRequestHeaders.ExpectContinue = false;
                        client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(Username + ":" + Password)));
                    }
                }
            }
    
            return client;
        }
    }
    
    public static TResponse Send<TResponse>(string endpoint, string payload, byte[] file)
    {
        string boundary = Guid.NewGuid().ToString("N");
        MultipartContent multipart = new MultipartContent("related", boundary);
    
        multipart.Headers.Remove("Content-Type");
        multipart.Headers.TryAddWithoutValidation("Content-Type", "multipart/related; boundary=\"" + boundary + "\"");
        multipart.Add(new StringContent(payload, Encoding.UTF8, "text/xml"));
    
        ByteArrayContent byteContent = new ByteArrayContent(file);
        byteContent.Headers.Remove("Content-Type");
        byteContent.Headers.Add("Content-Type", "application/pdf; name=test.pdf");
        byteContent.Headers.Add("Content-Transfer-Encoding", "binary");
        byteContent.Headers.Add("Content-ID", "<test.pdf>");
        byteContent.Headers.Add("Content-Disposition", "attachment; name=\"test.pdf\"; filename=\"test.pdf\"");
    
        multipart.Add(byteContent);
    
        var result = Client.PostAsync(@"urltowebservice", multipart).Result;
        result.EnsureSuccessStatusCode();
    
        var resultString = result.Content.ReadAsStringAsync().Result;
        TResponse resultTyped = XmlHelper.ToObject<TResponse>(resultString);
        return resultTyped;
    }

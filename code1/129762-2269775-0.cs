    public string GetRequest(Uri uri, int timeoutMilliseconds)
    {
        var request = System.Net.WebRequest.Create(uri);
        request.Timeout = timeoutMilliseconds;
        using (var response = request.GetResponse())
        using (var stream = response.GetResponseStream())
        using (var reader = new System.IO.StreamReader(stream))
        {
            return reader.ReadToEnd();
        }
    }

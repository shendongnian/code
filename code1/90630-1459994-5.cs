    protected override System.Net.WebRequest GetWebRequest(Uri uri)
    {
        WebRequest request = base.GetWebRequest(uri);
        request.Headers.Add("JSESSIONID", "XXXXX");
        return request;
    }

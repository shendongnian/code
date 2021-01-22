    public bool IsValidUri(Uri uri)
    {
        using (HttpClient Client = new HttpClient())
        {
        HttpResponseMessage result = Client.GetAsync(uri).Result;
        HttpStatusCode StatusCode = result.StatusCode;
        switch (StatusCode)
        {
            case HttpStatusCode.Accepted:
                return true;
            case HttpStatusCode.OK:
                return true;
             default:
                return false;
            }
        }
    }

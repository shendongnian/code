    public static Uri AddQuery(this Uri uri, string name, string value)
    {
        // this actually returns HttpValueCollection : NameValueCollection
        // which uses unicode compliant encoding on ToString()
        var query = HttpUtility.ParseQueryString(uri.Query);
    
        query.Add(name, value);
    
        var uriBuilder = new UriBuilder(uri)
        {
            Query = query.ToString()
        };
    
        return uriBuilder.Uri;
    }

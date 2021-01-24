    public Uri CreateMyApiUri(string rootUri, string apiPath, string entity, int pageSize)
    {
        var builder = new UriBuilder(rootUri);
        builder.Path = ConcatPathParts(builder.Path, apiPath, entity); //basically string.Join("/", args), plus code to remove superfluous slashes
        var parameters = HttpUtility.ParseQueryString(builder.Query);
        if (pageSize > 0) parameters["$top"] = pageSize.ToString();
        //the fix:
        builder.Query = Uri.EscapeUriString(HttpUtility.UrlDecode(parameters.ToString()));
        //instead of:
        //builder.Query = parameters.ToString();
        return builder.Uri; 
    }
    //called like this
    var uri = CreateMyApiUri("https://example.com", "data", "customers", 100);

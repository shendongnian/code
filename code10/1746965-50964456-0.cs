    public static string GetParentUri(this HttpRequest request, string parentRelativeUri)
    {
        string scheme;
        HostString host;
        PathString path;
        QueryString query;
        FragmentString fragment;
    
        UriHelper.FromAbsolute(request.GetDisplayUrl(), out scheme, out host, out path, out query, out fragment);             
             
        var pathBase = request.PathBase.ToString();
    
        return UriHelper.BuildAbsolute(scheme, host, 
            pathBase.Substring(0, pathBase.LastIndexOf("/")),
            parentRelativeUri);
    }

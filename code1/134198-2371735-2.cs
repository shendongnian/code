    public string MapPath(string path)
    {
        if (HttpContext.Current != null)
            return HttpContext.Current.Server.MapPath(path);
        if (path.StartsWith("~/")) {
            path = path.Substring( 2 );
        } else if (path.StartsWith("/")) {
            path = path.Substring( 1 );
        }
        // a non-prefixed path is already relative to your web server root
    
        return Path.Combine( HttpRuntime.AppDomainAppPath, path );
    }

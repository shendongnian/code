    public string GetWebAppRoot()
    {
        if(HttpContext.Current.Request.ApplicationPath == "/")
            return "http://" + HttpContext.Current.Request.Url.Host;
        else
            return "http://" + HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.ApplicationPath;
    }

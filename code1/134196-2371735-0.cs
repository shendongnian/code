    public string MapPath(string path)
    {
        if (HttpContext.Current != null)
            return HttpContext.Current.Server.MapPath(path);
    
        return HttpRuntime.AppDomainAppPath + path.Replace("~", string.Empty).Replace('/', '\\');
    }

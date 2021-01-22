    public string FullApplicationPath(HttpRequestBase request)
    {
    	var path = request.Url.AbsoluteUri.Replace(request.Url.AbsolutePath,string.Empty);
    	if (!string.IsNullOrEmpty(request.Url.Query))
    	{
    		path = path.Replace(request.Url.Query, string.Empty);
    	}
    	return path + request.ApplicationPath;
    }

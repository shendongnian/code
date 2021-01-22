    string _baseUrl = String.Empty;
    HttpContext httpContext = HttpContext.Current;
    if (httpContext != null)
    {
    	_baseURL = "http://" + HttpContext.Current.Request.Url.Host;
    	if (!HttpContext.Current.Request.Url.IsDefaultPort)
    	{
    		_baseURL += ":" + HttpContext.Current.Request.Url.Port;
    	}
    }

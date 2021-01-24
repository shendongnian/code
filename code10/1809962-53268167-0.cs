    public static string GetRequestData( string key, string defaultVal ) {
    	try {
    		var ctx = System.Web.HttpContext.Current;
    		var value = _ctx.Request.QueryString[key];
    		return string.IsNullOrEmpty(value) ? defaultVal : value;
    	} catch {
    		return defaultVal
    	}
    }

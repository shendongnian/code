    protected void Application_PreRequestHandlerExecute(HttpApplication sender, EventArgs e)
    {
    	string sExtentionOfThisFile = System.IO.Path.GetExtension(HttpContext.Current.Request.Path);
    
    	if (sExtentionOfThisFile.EndsWith("aspx", true, System.Globalization.CultureInfo.InvariantCulture) ||
    		sExtentionOfThisFile.EndsWith("ashx", true, System.Globalization.CultureInfo.InvariantCulture) ||
    		sExtentionOfThisFile.EndsWith("xml", true, System.Globalization.CultureInfo.InvariantCulture)
    		)
    	{			
    	   Response.Cache.SetExpires(DateTime.Now.AddSeconds(300));
    	   Response.Cache.SetCacheability(HttpCacheability.Public);        
       }
    }

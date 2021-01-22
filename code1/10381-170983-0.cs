    protected void Application_BeginRequest(Object sender, EventArgs e)
    {
        // If upper case letters are found in the URL, redirect to lower case URL.
        if (Regex.IsMatch(HttpContext.Current.Request.Url.ToString(), @"[A-Z]") == true)
        {
            string LowercaseURL = HttpContext.Current.Request.Url.ToString().ToLower();
    
    	    Response.Clear();
    	    Response.Status = "301 Moved Permanently";
    	    Response.AddHeader("Location",LowercaseURL);
    	    Response.End();
        }
    }

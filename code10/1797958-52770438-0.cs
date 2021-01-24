    void Application_AcquireRequestState(object sender, EventArgs e)
    {
    	if (HttpContext.Current.Session != null)
    	{
    		DateTime? userLastActive = (DateTime?)HttpContext.Current.Session["UserLastActive"];
    		if (userLastActive.HasValue && DateTime.Now.Subtract(userLastActive.Value).Minutes > 15)
    		{
    			Session.Abandon();
    			return;
    		}
    
    		// Check if the request for background tasks
    		var controller = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
    		var action = HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString();
    		if (controller == "BackGroundTaskController" &&
    			action == "BackGroundTaskAction")
    		{
    			// ignore
    			return;
    		}
    
    		HttpContext.Current.Session["UserLastActive"] = DateTime.Now;
    	}
    }

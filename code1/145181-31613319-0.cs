    if (System.Web.Hosting.HostingEnvironment.IsHosted  
        && System.Web.HttpContext.Current != null 
        && System.Web.HttpContext.Current.Handler != null 
        && System.Web.HttpContext.Current.Request != null)
    {
        //access the Request object here
    }

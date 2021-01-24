    var httpControllerRouteHandler = typeof(System.Web.Http.WebHost.HttpControllerRouteHandler).GetField("_instance",
    System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
    
    if (httpControllerRouteHandler != null)
    {
    	httpControllerRouteHandler.SetValue(null,
    		new Lazy<System.Web.Http.WebHost.HttpControllerRouteHandler>(() => new SessionStateRouteHandler(), true));
    }

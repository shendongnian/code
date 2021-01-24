    public static class WebApiConfig
    {
    	public static void Register(HttpConfiguration config)
    	{
    		config.MessageHandlers.Add(new LanguageMessageHandler()); // <- add this line
    		config.Routes.MapHttpRoute(
    			name: "DefaultApi",
    			routeTemplate: "api/{controller}/{id}",
    			defaults: new { id = RouteParameter.Optional }
    		);
    	}
    }

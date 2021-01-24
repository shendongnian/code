    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {            
            config.MessageHandlers.Add(new RequestHandler());
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }

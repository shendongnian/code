    public static class WebApiConfig  
    {  
        public static void Register(HttpConfiguration config)  
        {  
            var cors = new EnableCorsAttribute("http://localhost:18479", "*", "*");  
            config.EnableCors(cors);  
            // Web API configuration and services  
            // Web API routes  
            config.MapHttpAttributeRoutes();  
            config.Routes.MapHttpRoute(name: "DefaultApi", routeTemplate: "api/{controller}/{id}", defaults: new {  
            id = RouteParameter.Optional });  
        }  
    }  

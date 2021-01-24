    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            // Attribute routing.
            config.MapHttpAttributeRoutes();
    
            // Convention-based routing.
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}", //<<--- default web API route template
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }

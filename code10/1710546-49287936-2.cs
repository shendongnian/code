    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            // Convention-based routing.
            config.Routes.MapHttpRoute(
                name: "app-events",
                routeTemplate: "events",
                defaults: new { controller = "Events" },
                handler: new GZipToJsonHandler(GlobalConfiguration.Configuration),
                constraints: null
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }

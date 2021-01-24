    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
    
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}"
            );
    
            config.Services.Replace(typeof(IHttpActionSelector), new QueryParameterActionSelector());
        }
    }

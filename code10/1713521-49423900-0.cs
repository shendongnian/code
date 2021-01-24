     public static void Register(HttpConfiguration config)
            {
                // Web API configuration and services
    
                var cors = new EnableCorsAttribute("*", "*", "*");
                config.EnableCors(cors);
                //subhash
                log4net.Config.XmlConfigurator.Configure();
                // Web API routes
                config.MapHttpAttributeRoutes();
    
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{action}/{id}",
                    defaults: new { action = RouteParameter.Optional, id = RouteParameter.Optional }
                );
    
                var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
                jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    
                
                config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Unspecified;
    
                config.Services.Replace(typeof(IExceptionHandler), new CustomExceptionHandler());
            }

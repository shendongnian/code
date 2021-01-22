    public static void Register(HttpConfiguration config)
            {
                config.Routes.MapHttpRoute(
                    name: "AccountRouting",
                    routeTemplate: "cntrl/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
            }

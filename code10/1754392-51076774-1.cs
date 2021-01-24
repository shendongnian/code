    // Web API configuration and services
                var constraintResolver = new System.Web.Http.Routing.DefaultInlineConstraintResolver()
                {
                    ConstraintMap =
                    {
                        ["apiVersion"] = typeof(Microsoft.Web.Http.Routing.ApiVersionRouteConstraint)
                    }
                };
    
                config.AddVersionedApiExplorer(opt =>
                {
                    opt.SubstituteApiVersionInUrl = true;
    
                });
    
                config.MapHttpAttributeRoutes(constraintResolver);
                config.AddApiVersioning();
    
                // Web API routes
                //config.MapHttpAttributeRoutes();
    
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );

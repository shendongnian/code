            url = "YOUR URL";
            // Original path is stored and will be rewritten in the end
            var httpContext = new HttpContextWrapper(HttpContext.Current);
            string originalPath = httpContext.Request.Path;
            try
            {
                // Fake a request to the supplied URL into the routing system
                httpContext.RewritePath(url);
                RouteData urlRouteData = RouteTable.Routes.GetRouteData(httpContext);
                // If the route data was not found (e.g url leads to another site) then authorization is denied.
                // If you want to have a navigation to a different site, don't use AuthorizationMenu
                if(urlRouteData != null)
                {
                    string controllerName = urlRouteData.Values["controller"].ToString();
                    string actionName = urlRouteData.Values["action"].ToString();
                    // Get an instance of the controller that would handle this route
                    var requestContext = new RequestContext(httpContext, urlRouteData);
                    var controllerFactory = ControllerBuilder.Current.GetControllerFactory();
                    var controller = (ControllerBase) controllerFactory.CreateController(requestContext, controllerName);
                    // Find the action descriptor
                    var controllerContext = new ControllerContext(httpContext, new RouteData(), controller);
                    var controllerDescriptor = new ReflectedControllerDescriptor(controller.GetType());
                    var actionDescriptor = controllerDescriptor.FindAction(controllerContext, actionName);
                }
            }
            finally
            {
                // Reset our request path.
                httpContext.RewritePath(originalPath);
            }

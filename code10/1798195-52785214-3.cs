    public static class Extensions
    {
        /// <summary>
        /// Detect all the actions whose route should be generated dynamically
        /// </summary>
        /// <returns>List of actions</returns>
        private static IEnumerable<MethodInfo> GetTypesWithHelpAttribute()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    foreach (var method in type.GetMethods())
                    {
                        if (method.GetCustomAttributes(typeof(DynamicUrlAttribute), 
                                                true).Length > 0)
                        {
                            yield return method;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Get the list of routes to add to the Route Table
        /// </summary>
        /// <returns>List of routes</returns>
        public static List<Route> GetRoutes()
        {
            List<Route> routes = new List<Route>();
            foreach (var action in GetTypesWithHelpAttribute())
            {
                string controllerName = action.DeclaringType.Name.Replace("Controller","");
                string actionName = action.Name;
                List<string> parameters = new List<string>();
                int index = 0;
                foreach (var parameterInfo in action.GetParameters())
                {
                    parameters.Add(GetParamName(action, index++));
                }
                string parameterSection = action.GetParameters().Length > 0 ?
                        parameters.Aggregate("", (a, b) => $"{a}/{{{b}}}") 
                        : "";
                string finalRoute = $"dynamic/{controllerName}/{actionName}{parameterSection}";
                routes.Add(new Route(
                    url: finalRoute,
                    defaults: new RouteValueDictionary( 
                        new { 
                            controller = controllerName, 
                            action = actionName }),
                    routeHandler: new MvcRouteHandler()
                ));
            }
            return routes;
        }
        /// <summary>
        /// Return the name of the parameter by using reflection
        /// </summary>
        /// <param name="method">Method information</param>
        /// <param name="index">Parameter index</param>
        /// <returns>Parameter name</returns>
        public static string GetParamName(System.Reflection.MethodInfo method, int index)
        {
            string retVal = string.Empty;
            if (method != null && method.GetParameters().Length > index)
                retVal = method.GetParameters()[index].Name;
            return retVal;
        }
    }

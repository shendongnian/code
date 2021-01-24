    public class EndsWithRoute : RouteBase
    {
        private readonly Regex urlPattern;
        private readonly string controllerName;
        private readonly string actionName;
        private readonly string prefixName;
        private readonly string parameterName;
        public EndsWithRoute(string controllerName, string actionName, string prefixName, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(controllerName))
                throw new ArgumentException($"'{nameof(controllerName)}' is required.");
            if (string.IsNullOrWhiteSpace(actionName))
                throw new ArgumentException($"'{nameof(actionName)}' is required.");
            if (string.IsNullOrWhiteSpace(prefixName))
                throw new ArgumentException($"'{nameof(prefixName)}' is required.");
            if (string.IsNullOrWhiteSpace(parameterName))
                throw new ArgumentException($"'{nameof(parameterName)}' is required.");
            this.controllerName = controllerName;
            this.actionName = actionName;
            this.prefixName = prefixName;
            this.parameterName = parameterName;
            this.urlPattern = new Regex($"{prefixName}/[^/]+/?$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var path = httpContext.Request.Path;
            // Check if the URL pattern matches
            if (!urlPattern.IsMatch(path, 1))
                return null;
            // Get the value of the last segment
            var param = path.Split('/').Last();
            var routeData = new RouteData(this, new MvcRouteHandler());
            //Invoke MVC controller/action
            routeData.Values["controller"] = controllerName;
            routeData.Values["action"] = actionName;
            // Putting the myParam value into route values makes it
            // available to the model binder and to action method parameters.
            routeData.Values[parameterName] = param;
            return routeData;
        }
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            object controllerObj;
            object actionObj;
            object parameterObj;
            values.TryGetValue("controller", out controllerObj);
            values.TryGetValue("action", out actionObj);
            values.TryGetValue(parameterName, out parameterObj);
            if (controllerName.Equals(controllerObj.ToString(), StringComparison.OrdinalIgnoreCase) 
                && actionName.Equals(actionObj.ToString(), StringComparison.OrdinalIgnoreCase)
                && !string.IsNullOrEmpty(parameterObj.ToString()))
            {
                return new VirtualPathData(this, $"{prefixName}/{parameterObj.ToString()}".ToLowerInvariant());
            }
            return null;
        }
    }

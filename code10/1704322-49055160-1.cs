    public class NoProjectRouteConstraint : IRouteConstraint
    {
        //all the controllers that are exempt from having project id in URL...
        public const string c_ExemptControllers = "account|filedownload|restful|ping|public";
        private readonly string _controller;
        private readonly string _action;
                
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var m = c_ExemptControllers.Split('|').ToList();
            var controllerName = (values.ContainsKey("controller")) ? values["controller"].ToString() : "";
            var actionName = (values.ContainsKey("action")) ? values["action"].ToString() : "";
            var result = false;
            if (controllerName == string.Empty || actionName == string.Empty)
                return false;
            if (c_ExemptControllers.Contains(controllerName.ToLower()))
            {
                result = true;
            }
            return result;
        }
    }

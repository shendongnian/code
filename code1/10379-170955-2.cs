    public class LowercaseConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route,
                string parameterName, RouteValueDictionary values,
                RouteDirection routeDirection)
        {
            string value = (string)values[parameterName];
            return Equals(value, value.ToLower());
        }

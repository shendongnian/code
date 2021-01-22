    public class LowercaseConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route,
                string parameterName, RouteValueDictionary values,
                RouteDirection routeDirection)
        {
            string value = values[parameterName] as string;
            string lowercase = value.ToLower();
            if (value.Equals(lowercase))
                return true;
            else
                return false;
            }
        }

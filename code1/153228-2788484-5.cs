    public class FromValuesListConstraint : IRouteConstraint
    {
        private List<string>_values;
        public FromValuesListConstraint(params string[] values)
        {
            this._values = values.Select(x => x.ToLower()).ToList();
        }
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            string value = values[parameterName].ToString();
            return _values.Contains(value.ToLower());
        }
    }

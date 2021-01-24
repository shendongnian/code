    public class CustomApiVersionRouteConstraint : IHttpRouteConstraint
    {
        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, 
            IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            if (string.IsNullOrEmpty(parameterName))
            {
                return false;
            }
            var properties = request.ApiVersionProperties();
            var versionString = "";
            if (values.TryGetValue(parameterName, out object value))
            {
                //This is the real 'magic' here, just replacing the underscore with a period
                versionString = ((string) value).Replace('_', '.');
                
                properties.RawApiVersion = versionString;
            }
            else
            {
                return false;
            }
            if (ApiVersion.TryParse(versionString, out var requestedVersion))
            {
                properties.ApiVersion = requestedVersion;
                return true;
            }
            return false;
        }
    }

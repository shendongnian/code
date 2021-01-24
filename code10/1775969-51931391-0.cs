    public static class UrlHelperExtensions
    {
    
        public static string RouteWithSameQueryParams(this IUrlHelper url, object routeValues)
        {
            var resultRouteValues = new RouteValueDictionary(url.ActionContext.RouteData.Values);
    
            foreach (var queryValue in url.ActionContext.HttpContext.Request.Query)
            {
                resultRouteValues.Add(queryValue.Key, queryValue.Value);
            }
    
            if (routeValues == null)
                return url.RouteUrl(resultRouteValues);
    
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(routeValues))
            {
                if (resultRouteValues.ContainsKey(descriptor.Name))
                {
                    resultRouteValues[descriptor.Name] = descriptor.GetValue(routeValues);
                }
                else
                {
                    resultRouteValues.Add(descriptor.Name, descriptor.GetValue(routeValues));
                }
            }
    
            return url.RouteUrl(resultRouteValues);
        }
    
        public static string RouteWithoutValue(this IUrlHelper url, string param, string value)
        {
            var resultRouteValues = new RouteValueDictionary(url.ActionContext.RouteData.Values);
    
            foreach (var queryValue in url.ActionContext.HttpContext.Request.Query)
            {
                if (queryValue.Key.ToLower() == param)
                {
                    if (value != null)
                        resultRouteValues.Add(queryValue.Key, new StringValues(queryValue.Value.Where(s => s != value).ToArray()));
                }
                else
                    resultRouteValues.Add(queryValue.Key, queryValue.Value);
            }
    
            return url.RouteUrl(resultRouteValues);
        }
    
        public static string RouteWithAddedValues(this IUrlHelper url, string param, params string[] values)
        {
            var resultRouteValues = new RouteValueDictionary(url.ActionContext.RouteData.Values);
    
            foreach (var queryValue in url.ActionContext.HttpContext.Request.Query)
            {
                if (queryValue.Key.ToLower() == param)
                {
                    var vals = new List<string>(queryValue.Value);
                    vals.AddRange(values);
                    resultRouteValues.Add(queryValue.Key, new StringValues(vals.ToArray()));
                }
                else
                {
                    resultRouteValues.Add(queryValue.Key, queryValue.Value);
                }
            }
    
            if (!resultRouteValues.ContainsKey(param))
            {
                resultRouteValues.Add(param, new StringValues(values));
            }
    
            return url.RouteUrl(resultRouteValues);
        }
    
    }

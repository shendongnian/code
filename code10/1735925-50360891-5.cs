    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;
    namespace DL.SO.Framework.Mvc.Extensions
    {
        public static class UrlHelperExtensions
        {
            public static string Current(this IUrlHelper url, object routeValues)
            {
                // Convert new route values to a dictionary
                var newRouteData = new RouteValueDictionary(routeValues);
                // Get current route data
                var currentRouteData = url.ActionContext.RouteData.Values;
                // Get current route query string and add them back to the new route
                var currentQuery = url.ActionContext.HttpContext.Request.Query;
                foreach (var param in currentQuery)
                {
                    currentRouteData[param.Key] = param.Value;
                }
                // Merge new route data
                foreach (var item in newRouteData)
                {
                    currentRouteData[item.Key] = item.Value;
                }
                return url.RouteUrl(currentRouteData);
            }
        }
    }

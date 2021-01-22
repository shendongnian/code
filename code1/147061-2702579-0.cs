    public static string GenerateUrl(string routeName, string actionName, string controllerName, RouteValueDictionary routeValues, RouteCollection routeCollection, RequestContext requestContext, bool includeImplicitMvcValues) {
            if (routeCollection == null) {
                throw new ArgumentNullException("routeCollection");
            }
            if (requestContext == null) {
                throw new ArgumentNullException("requestContext");
            }
            RouteValueDictionary mergedRouteValues = RouteValuesHelpers.MergeRouteValues(actionName, controllerName, requestContext.RouteData.Values, routeValues, includeImplicitMvcValues);
            VirtualPathData vpd = routeCollection.GetVirtualPathForArea(requestContext, routeName, mergedRouteValues);
            if (vpd == null) {
                return null;
            }
            string modifiedUrl = PathHelpers.GenerateClientUrl(requestContext.HttpContext, vpd.VirtualPath);
            return modifiedUrl;
        }

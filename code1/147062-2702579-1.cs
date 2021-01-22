    internal static VirtualPathData GetVirtualPathForArea(this RouteCollection routes, RequestContext requestContext, string name, RouteValueDictionary values, out bool usingAreas) {
            if (routes == null) {
                throw new ArgumentNullException("routes");
            }
            if (!String.IsNullOrEmpty(name)) {
                // the route name is a stronger qualifier than the area name, so just pipe it through
                usingAreas = false;
                return routes.GetVirtualPath(requestContext, name, values);
            }
            string targetArea = null;
            if (values != null) {
                object targetAreaRawValue;
                if (values.TryGetValue("area", out targetAreaRawValue)) {
                    targetArea = targetAreaRawValue as string;
                }
                else {
                    // set target area to current area
                    if (requestContext != null) {
                        targetArea = AreaHelpers.GetAreaName(requestContext.RouteData);
                    }
                }
            }
            // need to apply a correction to the RVD if areas are in use
            RouteValueDictionary correctedValues = values;
            RouteCollection filteredRoutes = FilterRouteCollectionByArea(routes, targetArea, out usingAreas);
            if (usingAreas) {
                correctedValues = new RouteValueDictionary(values);
                correctedValues.Remove("area");
            }
            VirtualPathData vpd = filteredRoutes.GetVirtualPath(requestContext, correctedValues);
            return vpd;
        }

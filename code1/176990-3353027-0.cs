    public static class ActionLinkExtensions
    {
        public static MvcHtmlString ActionLink(this HtmlHelper helper, string linkText, string actionName, bool addExistingRouteValues)
        {
            return ActionLink(helper, linkText, actionName, null, null, addExistingRouteValues, null);
        }
    
        public static MvcHtmlString ActionLink(this HtmlHelper helper, string linkText, string actionName, object routeValues, bool addExistingRouteValues)
        {
            return ActionLink(helper, linkText, actionName, null, routeValues, addExistingRouteValues, null);
        }
    
        public static MvcHtmlString ActionLink(this HtmlHelper helper, string linkText, string actionName, string controllerName, object routeValues, bool addExistingRouteValues, object htmlAttributes)
        {
            var queryString = helper.ViewContext.HttpContext.Request.QueryString;
            var newRouteValues = routeValues == null ? helper.ViewContext.RouteData.Values : new RouteValueDictionary(routeValues);
    
            if (addExistingRouteValues)
            {
                foreach (string key in queryString.Keys)
                {
                    if (!newRouteValues.ContainsKey(key))
                        newRouteValues.Add(key, queryString[key]);
                }
            }
    
            return MvcHtmlString.Create(HtmlHelper.GenerateLink(helper.ViewContext.RequestContext, helper.RouteCollection, linkText, null, actionName, controllerName, newRouteValues, new RouteValueDictionary(htmlAttributes)));
        }
    }

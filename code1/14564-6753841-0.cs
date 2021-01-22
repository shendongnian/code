        public static MvcHtmlString MyLink(this HtmlHelper helper, string linkText, string actionName, object routeValues)
        {
            RouteValueDictionary routeValueDictionary = new RouteValueDictionary(routeValues);
            // Add more parameters
            foreach (string parameter in helper.ViewContext.RequestContext.HttpContext.Request.QueryString.AllKeys)
            {
                routeValueDictionary.Add(parameter, helper.ViewContext.RequestContext.HttpContext.Request.QueryString[parameter]);
            }
            return helper.ActionLink(linkText, actionName, routeValueDictionary);
        }

    public static string ExternalAction(this UrlHelper helper, string actionName, string controllerName = null, RouteValueDictionary routeValues = null, string protocol = null)
    {
    #if DEBUG
        var client = new HttpClient();
        var ipAddress = client.GetStringAsync("http://ipecho.net/plain").Result; 
        // above 2 lines should do it..
        var route = UrlHelper.GenerateUrl(null, actionName, controllerName, routeValues, helper.RouteCollection, helper.RequestContext, true); 
        if (route == null)
        {
            return route;
        }
        if (string.IsNullOrEmpty(protocol) && string.IsNullOrEmpty(ipAddress))
        {
            return route;
        }
        var url = HttpContext.Current.Request.Url;
        protocol = !string.IsNullOrWhiteSpace(protocol) ? protocol : Uri.UriSchemeHttp;
        return string.Concat(protocol, Uri.SchemeDelimiter, ipAddress, route);
    #else
        helper.Action(action, null, null, HttpContext.Current.Request.Url.Scheme)
    #endif
    }

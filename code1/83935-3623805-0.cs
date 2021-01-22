    public static string AbsoluteAction(this UrlHelper url, string action, string controller, object routeValues)
    {
        Uri requestUrl = url.RequestContext.HttpContext.Request.Url;
        string absoluteAction = string.Format("{0}://{1}{2}",
                                              requestUrl.Scheme,
                                              requestUrl.Authority,
                                              url.Action(action, controller, routeValues, null));
        return absoluteAction;
    }

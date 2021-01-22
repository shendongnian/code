    public static class Redirector {
            public static void RedirectTo(this Controller ct, string action) {
                UrlHelper urlHelper = new UrlHelper(ct.ControllerContext.RequestContext);
    
                ct.Response.Headers.Add("AjaxRedirectURL", urlHelper.Action(action));
            }
    
            public static void RedirectTo(this Controller ct, string action, string controller) {
                UrlHelper urlHelper = new UrlHelper(ct.ControllerContext.RequestContext);
    
                ct.Response.Headers.Add("AjaxRedirectURL", urlHelper.Action(action, controller));
            }
    
            public static void RedirectTo(this Controller ct, string action, string controller, object routeValues) {
                UrlHelper urlHelper = new UrlHelper(ct.ControllerContext.RequestContext);
    
                ct.Response.Headers.Add("AjaxRedirectURL", urlHelper.Action(action, controller, routeValues));
            }
        }

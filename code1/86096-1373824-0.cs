    public static class UserUrlExtensions
    {
        // Create whichever overloads you want
        public static string UserActionLink(this HtmlHelper helper, string linkText, RouteValueCollection routeValues)
        {
            // Get whatever value it is you want from the current context
            routeValues["User"] = helper.ViewContext.HttpContext.Current.User.Identity.Name;
            
            return helper.ActionLink(linkText, routeValues);
        }
    }

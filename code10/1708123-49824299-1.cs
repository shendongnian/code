    class AuthorizeNoCaching : AuthorizeAttribute
    {
        ////https://stackoverflow.com/questions/10011780/prevent-caching-in-asp-net-mvc-for-specific-actions-using-an-attribute?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //filterContext.HttpContext.Response.Cache.SetAllowResponseInBrowserHistory(false);  //We want them to be able to see the pages they've been to in the browser history for now.
            //https://stackoverflow.com/questions/866822/why-both-no-cache-and-no-store-should-be-used-in-http-response
            filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            filterContext.HttpContext.Response.Cache.SetNoStore();
            filterContext.HttpContext.Response.Cache.SetExpires(DateTime.Now);
            filterContext.HttpContext.Response.Cache.SetValidUntilExpires(true);
            base.OnAuthorization(filterContext);
        }
    }

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomAuthorizeAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var routeData = httpContext.Request.RequestContext.RouteData;
            var controller = routeData.GetRequiredString("controller");
            var action = routeData.GetRequiredString("action");
            var area = routeData.DataTokens["area"];
            var user = httpContext.User;
            if (area != null && area.ToString() == "Customer")
            {
                if (!user.Identity.IsAuthenticated)
                    return false;
            }
            else if (area != null && area.ToString() == "Admin")
            {
                if (!user.Identity.IsAuthenticated)
                    return false;
                if (!user.IsInRole("Admin"))
                    return false;
            }
            return true;
        }
    }

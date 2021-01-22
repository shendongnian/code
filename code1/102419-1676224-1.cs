    public class RequiresClaim : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var claim = GetClaim(filterContext.RouteData["id"]);
    
            if (claim == null) { filterContext.Result = new ViewResult { ViewName = "ClaimNotFound" }; }
        }
    }

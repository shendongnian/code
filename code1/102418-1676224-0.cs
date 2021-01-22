    public class RequiresClaim : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var claim = GetClaim(Id);
    
            if (claim == null) { filterContext.Result = new ViewResult { ViewName = "ClaimNotFound" }; }
        }
    }

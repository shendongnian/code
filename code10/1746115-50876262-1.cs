    public class AuthorizeForCustomer : System.Web.Http.AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var isAuthorized = base.IsAuthorized(actionContext);
            string clientId = ""; //Get client ID from actionContext.Request;
            var user = actionContext.ControllerContext.RequestContext.Principal as ClaimsPrincipal;
            var claim = user.FindFirst(this.Roles);
            var clientIds = claim.Value.Split('|');
            return isAuthorized && clientIds.Contains(clientId);
        }
    }

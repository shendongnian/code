    public class CustomAuthorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Error"); //Change "~/Error" to be the path to your error view
        }
 
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var personLoggedIn = filterContext.HttpContext.User.Identity.Name.Split('\\')[1];
            if (_context.UserTable.Single(x => x.UserLogon == personLoggedIn).IsAdministrator == false)
            {
                base.OnAuthorization(filterContext);
            }
            else
            {
                this.HandleUnauthorizedRequest(filterContext);
            }
        }
    }

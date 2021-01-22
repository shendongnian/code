    [Authorize(Roles = "Role1, Role2")]
    public class BaseController : Controller
    {
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!User.IsInRole("Role1") && !User.IsInRole("Role2"))
            {
                filterContext.Result = View("LogonView");
            }
            base.OnAuthorization(filterContext);
        }
    }

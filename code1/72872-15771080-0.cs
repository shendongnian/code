    [Authorize]
    public class BaseController : Controller
    {
        protected override void OnAuthorization(AuthorizationContext authContext)
        {
            if
                (
                !User.Identity.IsAuthenticated &&
                Request.LogonUserIdentity != null &&
                Request.LogonUserIdentity.IsAuthenticated
                )
            {
                var logonUserIdentity = Request.LogonUserIdentity.Name;
                if (!string.IsNullOrEmpty(logonUserIdentity))
                {
                    if (logonUserIdentity.Contains("\\"))
                        logonUserIdentity = logonUserIdentity.Substring(logonUserIdentity.IndexOf("\\") + 1);
                    var db = new UsersContext();
                    var loginUser =
                        db.UserProfiles.FirstOrDefault(x => x.UserName == logonUserIdentity);
                    //Auto-Login Windows Identity
                    if (loginUser == null)
                        loginUser = CreateUser(db, logonUserIdentity);
                    if (loginUser != null)
                    {
                        FormsAuthentication.SetAuthCookie(loginUser.UserName, true);
                        string returnUrl = Request.RawUrl;
                        if (!string.IsNullOrEmpty(returnUrl))
                            Response.Redirect(returnUrl);
                        Response.Redirect("~/");
                    }
                }
            }
        }
        private static UserProfile CreateUser(UsersContext db, string logonUserIdentity)
        {
            var user = new UserProfile {UserName = logonUserIdentity};
            db.UserProfiles.Add(user);
            db.SaveChanges();
            return user;
        }
    }

    public abstract class ApplicationController : Controller {
        private IUserRepository _repUser;
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            _repUser = RepositoryFactory.getUserRepository();
            var loggedInUser = _repUser.FindById(filterContext.HttpContext.User.Identity.Name); //Problem!
            ViewData["LoggedInUser"] = loggedInUser;
        }
    }

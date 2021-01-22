	public class MasterPageDataAttribute : ActionFilterAttribute
	    {
	        public override void OnActionExecuting(ActionExecutingContext filterContext)
	        {
	            base.OnActionExecuting(filterContext);
	            IUserRepository _repUser = RepositoryFactory.getUserRepository();
	            IPrincipal siteUser = filterContext.Controller.ControllerContext.HttpContext.User;
	            User loggedInUser = null;
	            if (siteUser == null || siteUser.Identity.Name == null)
	            {
	                //do nothing
	            }
	            else
	            {
	                loggedInUser = _repUser.findUserById(siteUser.Identity.Name);
	            }
	            filterContext.Controller.ViewData["LoggedInUser"] = loggedInUser ?? new User { Nickname = "Guest" };
	        }
	    }

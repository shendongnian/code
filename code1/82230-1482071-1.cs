    public class CustomControllerClass : Controller
    {
        public User CurrentUser;
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
			
			if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
				string userName = requestContext.HttpContext.User.Identity.Name;
                CurrentUser = UserRepository.GetUser(userName);
                ViewData["CurrentUser"] = CurrentUser;
            }
            else
                ViewData["CurrentUser"] = null;
        }
	}

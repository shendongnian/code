    public class CustomControllerClass : Controller
    {
        public User CurrentUser { get; set; }
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
			if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
				string userName = requestContext.HttpContext.User.Identity.Name;
                CurrentUser = UserRepository.GetUser(userName);
            }
            ViewData["CurrentUser"] = CurrentUser;                
        }
	}

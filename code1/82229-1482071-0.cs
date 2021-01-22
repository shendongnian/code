    public class CustomControllerClass : Controller
    {
        public User TheUser;
        protected override void Execute(System.Web.Routing.RequestContext requestContext)
        {
             if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                TheUser = UserRepository.GetUser(requestContext.HttpContext.User.Identity.Name);
                ViewData["TheUser"] = TheUser;
            }
            else
                ViewData["TheUser"] = null;
        }

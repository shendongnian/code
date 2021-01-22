    public abstract class ApplicationController : Controller
    {
        private IUserRepository _repUser;
        public ApplicationController()
        {
        }
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            _repUser = RepositoryFactory.getUserRepository();
            var loggedInUser = _repUser.FindById(User.Identity.Name);
            ViewData["LoggedInUser"] = loggedInUser;
        }
    }

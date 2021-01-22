    public abstract class BaseController : Controller
    {
        public bool LoggedOn
        {
            get { return User.Identity.IsAuthenticated; }
        }
    }

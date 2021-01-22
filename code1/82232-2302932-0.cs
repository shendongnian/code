    public abstract class BaseController : Controller
    {
        int _UserId = 0;
    
        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
    
        public BaseController()
        {
            var userFromAuthCookie = System.Threading.Thread.CurrentPrincipal;
    
            if (userFromAuthCookie != null  && userFromAuthCookie.Identity.IsAuthenticated) // && !String.IsNullOrEmpty(userFromAuthCookie.Identity.Name))
            {
                busUser userBO = AceFactory.GetUser();
                string userNameFromAuthCookie = userFromAuthCookie.Identity.Name;
                _UserId = userBO.GetUserIdByUsername(userNameFromAuthCookie);
            }
        }

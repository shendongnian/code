    public abstract class YourController : Controller
    {
        public YourController()
        {
            var user = System.Threading.Thread.CurrentPrincipal;
            TheUser = User.Identity.IsAuthenticated ? UserRepository.GetUser(user.Identity.Name) : null;
            ViewData["TheUser"] = TheUser;  
        }
    }

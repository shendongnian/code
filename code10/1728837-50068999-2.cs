    public class HomeController : Controller
    {
        private readonly IUserSession _userSession;
        public HomeController(IUserSession userSession)
        {
            _userSession = userSession;
        }
        public IActionResult OpretLobby()
        {
            var currentUser = _userSession.User;
            return View(currentUser);
        }
    }

    public class ExampleController : Controller
    {
        private readonly IUserService _userService;
        
        public ExampleController(IUserService userService)
        {
            _userService = userService;
        }
        
        public IActionResult Index()
        {
            var isLoggedIn = _userService.IsUserLoggedIn();
        
            // …
        
            return View();
        }
    }

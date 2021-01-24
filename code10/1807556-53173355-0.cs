    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            _httpContextAccessor.HttpContext.Session.SetString("session1", Guid.NewGuid().ToString());
            return View();
        }
    }

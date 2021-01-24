    public class HomeController : Controller
    {
        [HttpGet("", Name = RouteNames.Home)]
        public IActionResult Index() => View();
    }

    public class HomeController : Controller
    {
        public IActionResult Index(string lang)
        {
            ViewData["lang"] = lang; // Using ViewData just for demonstration purposes.
            return View();
        }
    }

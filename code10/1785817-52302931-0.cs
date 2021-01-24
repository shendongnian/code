    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    
        public IActionResult Blah()
        {
            // here invoke some function which fires the .exe file
            return RedirectToAction(nameof(Index));
        }
    }

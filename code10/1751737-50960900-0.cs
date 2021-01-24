    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Login","Account",null);
        }
    }

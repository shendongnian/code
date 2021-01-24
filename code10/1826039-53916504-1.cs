    public class HomeController : Controller
    {
        public IActionResult About()
        {
            var someCookie = HttpContext.Request.Cookies["someCookie"];
    
            return View();
        }
    }

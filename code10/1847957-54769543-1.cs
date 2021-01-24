    public class HomeController : Controller
    {
        [ViewData]
        public string Title { get; set; }
    
        public IActionResult About()
        {
            Title = "About Us";
            ViewData["Message"] = "Your application description page.";
    
            return View();
        }
    }

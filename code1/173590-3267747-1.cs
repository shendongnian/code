    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new MyViewModel
            {
                // you probably would fetch those from the database
                Countries = new SelectList(new[] 
                {
                    new { Value = "FR", Text = "France" },
                    new { Value = "US", Text = "USA" } 
                }, "Value", "Text")
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(string selectedCountry)
        {
            // selectedCountry will contain the code that you could use to 
            // query your database
            return RedirectToAction("index");
        }
    }

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new ProductListingViewModel
            {
                Categories = new SelectList(new[]
                {
                    new { Value = "1", Text = "category 1" },
                    new { Value = "2", Text = "category 2" }
                }, "Value", "Text")
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(ProductListingViewModel model)
        {
            return View(model);
        }
    }

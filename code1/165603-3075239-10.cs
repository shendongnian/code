    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var products = new[]
            {
                new Product { Id = 1, Name = "product 1", IsInStock = false },
                new Product { Id = 2, Name = "product 2", IsInStock = true },
                new Product { Id = 3, Name = "product 3", IsInStock = false },
                new Product { Id = 4, Name = "product 4", IsInStock = true },
            };
            return View(products);
        }
        [HttpPost]
        public ActionResult Index(int[] isInStock)
        {
            // The isInStock array will contain the ids of selected products
            // TODO: Process selected products
            return RedirectToAction("Index");
        }
    }

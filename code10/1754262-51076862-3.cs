    namespace ExampleWebAppilcationTest.Controllers
    {
        public class HomeController : Controller
        {
            [HttpGet]
            public ActionResult Index()
            {
                using (var dbContext = new ExampleDB())
                {
                    var model = dbContext.TData.ToList();
                    return View(model);
                }
            }
    
            [HttpPost]
            public ActionResult Index(TableData data)
            {
                using (var dbContext = new ExampleDB())
                {
                    dbContext.TData.Add(data);
                    dbContext.SaveChanges();
                }
    
                return RedirectToAction("Index");
            }
        }
    }

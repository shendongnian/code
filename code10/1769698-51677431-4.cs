    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<TestObject> main = (List<TestObject>)TempData["yourData"];
            if (main == null)
            {
                main = new List<TestObject>();
                main.Add(new TestObject("1"));
                main.Add(new TestObject("2"));
                main.Add(new TestObject("3"));
                main.Add(new TestObject("4"));
                main.Add(new TestObject("5"));
            }
            return View("Index", main);
        }
        [HttpPost]
        public ActionResult Create()
        {
            List<TestObject> main = (List<TestObject>)TempData["FullModel"];
            TempData["yourData"] = main;
            return RedirectToAction(nameof(Index));
        }
    }

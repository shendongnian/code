    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new Project());
        }
        [HttpPost]
        public ActionResult Index(ProjectSearch gridModel)
        {
            // gridModel.Search should be correctly bound here
            return RedirectToAction("Index");
        }
    }

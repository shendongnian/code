        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                return View();
            }
    
        [ActionName("Different")]
        [SubmitCommand("DoSave")]
        public ActionResult DifferentSave()
        {
          TempData["message"] = "saved! - defferent";
          return View("Index");
        }
    
        [ActionName("Different")]
        [SubmitCommand("DoDelete")]
        public ActionResult DifferentDelete()
        {
          TempData["message"] = "deleted! - defferent";
          return View("Index");
        }
    
        [ActionName("Same")]
        [SubmitCommand("DoSubmit","Save")]
        public ActionResult SameSave()
        {
          TempData["message"] = "saved! - same";
          return View("Index");
        }
    
        [ActionName("Same")]
        [SubmitCommand("DoSubmit","Delete")]
        public ActionResult SameDelete()
        {
          TempData["message"] = "deleted! - same";
          return View("Index");
        }
      }

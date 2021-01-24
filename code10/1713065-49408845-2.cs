    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            var errGUID = (string)Session["test"];
            ViewBag.ErrorMessage = errGUID;
            
            return View();
        }
    }

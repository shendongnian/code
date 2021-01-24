    public class MyController : Controller {
        [HandleError(View = "Error")]
        public ActionResult Index(string name) {
            return View("Index", new MyViewModel() {
                Name = name,
                Link = Request.UrlReferrer
            });
        }
    }

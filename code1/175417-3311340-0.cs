    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Action to render the form, initialize the model
            // with some default value
            var model = new MyModel
            {
                RdPageType = true
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(MyModel model)
        {
            // Action called when the form is posted
            // model.RdPageType will depend on the radio
            // being selected
            return View(model);
        }
    }

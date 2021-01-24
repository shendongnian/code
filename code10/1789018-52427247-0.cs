    public class DefaultsController : Controller {
        [HttpGet]
        public ActionResult Index() {
            var model = new Vehicule();
            return View(mdoel);
        }
    
        [HttpPost]
        public ActionResult Index(Vehicule model) {
            if(ModelState.IsValid) {
                //...do something
                //..possible redirect 
            }
            //if we get this far something is wrong with data
            return View(model);
        }
    }

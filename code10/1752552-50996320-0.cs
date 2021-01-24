    //Your base controller
    public class BaseController : Controller
    {
        //This will be executed after every action call on the controllers inherited from this BaseController.
        //You can use OnActionExecuting in case you want the execution before the actions execution in your other controllers.
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Controller controller = filterContext.Controller as Controller;
            if (controller != null)
            {
                var customer = controller.TempData["customer"] as Customer;
                //do stuff with customer
                Controller.TempData["customer"] = customer;
            }
        }
    }
    //Then your other controller
    public class HomeController : BaseController
    {
        public ActionResult Index(StepOne data)
        {
            //You can get your TempData here too.
            var customer = TempData["customer"] as Customer;
            return View();
        }
    }

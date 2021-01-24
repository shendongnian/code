    namespace CustomControllerFactory.Core.Controllers
    {
    	public class DemoController : Controller
    	{
    		public ActionResult Index()
    		{
    			ViewBag.CalledFrom = "Core";
    			return View();
    		}
    	}
    }
    
    namespace CustomControllerFactory.Client.Controllers
    {
    	public class DemoController : Controller
    	{
    		public ActionResult Index()
    		{
    			ViewBag.CalledFrom = "Client";
    			return View();
    		}
    	}
    }

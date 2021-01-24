    namespace MvcRequiredCheckbox
    {
	    public class HomeController : Controller
	    {
		    public ActionResult Index()
		    {
		    	return View();
		    }
		    [HttpPost]
		    public ActionResult Index(SampleViewModel viewModel)
		    {
		    	if(!ModelState.IsValid)
		    	{
		    		return View(viewModel);
			    }
			
			    return Content("Success");
		    }
	    }
    }

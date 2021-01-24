    public class HomeController : Controller
    {
    	public IActionResult Index()
    	{
    		return View();
    	}
    
    	[Route("test")]
    	[AllowAnonymous]
    	public IActionResult Test()
    	{
    		return View();
    	}
    }

    public class HomeController : Controller
    {
    	private readonly ServicesConfiguration _config;
    
    	public HomeController(ServicesConfiguration config)
    	{
    		_config = config ?? throw new ArgumentNullException(nameof(config));
    	}
    }

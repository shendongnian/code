    public class HomeController : Controller
    {
    	private readonly MvcConfig _mvcConfig;
    	public HomeController(MvcConfig mvcConfig)
    	{
    		_mvcConfig = mvcConfig;
    	}
        public bool GetIsIndented()
        {
            return _mvcConfig.Formatting == Newtonsoft.Json.Formatting.Indented;
        }
    }

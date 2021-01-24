    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
    	private readonly MyAppConfig _appConfig;
    
    	public ValuesController(IOptions<MyAppConfig> optionsAccessor)
    	{
    		if (optionsAccessor == null) throw new ArgumentNullException(nameof(optionsAccessor));
    		_appConfig = optionsAccessor.Value;
    	}
    	
    	// GET api/values/5
    	[HttpGet("{id}")]
    	public string Get(int id)
    	{
    		return _appConfig.SomeConfig;
    	}
    }

    public class ValuesController : ControllerBase
    {
    	IServiceScopeFactory _serviceScopeFactory
    	public ValuesController(IServiceScopeFactory serviceScopeFactory)
    	{
    		_serviceScopeFactory = serviceScopeFactory;
    	}
    	public async Task<string> foo(string msg)
    	{
    		Thread x = new Thread(async () =>
    		{
    			using(var scope = _serviceScopeFactory.CreateScope())
    			{
    				var db = scope.ServiceProvider.GetService<MyDBContext>();
    				await bar(db, msg);
    			}
    		});
    
    		x.IsBackground = true;
    		x.Start();
    
    		return "OK.";
    	}
    }

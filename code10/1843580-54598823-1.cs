    public class ValuesController : ControllerBase
    {
    	IServiceScopeFactory _serviceScopeFactory
    	public ValuesController(IServiceScopeFactory serviceScopeFactory)
    	{
    		_serviceScopeFactory = serviceScopeFactory;
    	}
    	public async Task<string> foo(string msg)
    	{
    		var task = Task.Run(async () =>
    		{
    			using (var scope = _serviceScopeFactory.CreateScope())
    			{
    				var db = scope.ServiceProvider.GetService<MyDBContext>();
    				await bar(db, msg);
    			}
    
    		});
            // you may wait or not when task completes
    		return "OK.";
    	}
    }

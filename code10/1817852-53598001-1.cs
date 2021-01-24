    public class Middle
    {
    	private readonly RequestDelegate _next;
    	private readonly MiddleConfig _opt = new MiddleConfig();
    
    	public Middle(RequestDelegate next, MiddleConfig options)
    	{
    		_opt = options;
    		_next = next;
    	}
    
    	public async Task Invoke(HttpContext context)
    	{
    		await _next.Invoke(context);
    	}
    }

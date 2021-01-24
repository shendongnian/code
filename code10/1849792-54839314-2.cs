    public class MyService
    {
    	private IHttpContextAccessor _httpContextAccessor;
    	public MyService(IHttpContextAccessor httpContextAccessor)
    	{
    		_httpContextAccessor = httpContextAccessor;
    	}
    	
    	public void MyMethod()
    	{
    		// Use HttpContext like this
    		var username = _httpContextAccessor.HttpContext.User.Identity.Name;
    	}
    }

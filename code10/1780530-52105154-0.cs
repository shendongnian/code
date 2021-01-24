    public class AdminSecurityMiddleware
    {
    	private readonly RequestDelegate _next;
    	IUserRepository userRepository;
    
    	public AdminSecurityMiddleware(RequestDelegate next, IUserRepository userRepository)
    	{
    		_next = next;
    		_userRepository = userRepository;
    	}
    
    	public async Task Invoke(HttpContext context)
    	{
    		bool isAdminUserBlocksApiRoute; 
    		//check for route here. As I know there is no elegant way to get name of the route since context.GetRouteData() returns null until mvc middleware is called.
    		// probably you can check like this context.Request.Path.StartsWithSegments("/api/admin")
    		
    		if (isAdminUserBlocksApiRoute)
    		{
    			bool isUserAuthorized;
    			// check here for Authorization
    			if (!isUserAuthorized)
    			{
    				context.Response.Clear();
    				context.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
    				await context.Response.WriteAsync("Unauthorized");
    				return;
    			}
    
    			// adding custom claims
    			var identity = new ClaimsIdentity(new GenericIdentity("user.Id"), new[] { new Claim("user_id", "id") });
    			context.User.AddIdentity(identity);
    		}
    		await _next.Invoke(context);
    	}
    }

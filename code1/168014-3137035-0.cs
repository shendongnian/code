    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
    	protected override bool AuthorizeCore(HttpContextBase httpContext)
    	{
    		return httpContext.User.IsInRole("Admin");
    	}
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    	public class AuthoriseRedirect : AuthorizeAttribute
    	{
    		protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    		{
    			filterContext.RequestContext.HttpContext.Response.Redirect("UrlToRedirectTo");
    		}
    	}

    public class InternalOnly : FilterAttribute
    {
    	public void OnAuthorization (AuthorizationContext filterContext)
    	{
    		if (!IsIntranet (filterContext.HttpContext.Request.UserHostAddress))
    		{
    			throw new HttpException ((int)HttpStatusCode.Forbidden, "Access forbidden.");
    		}
    	}
    
    	private bool IsIntranet (string userIP)
    	{
    		// match an internal IP (ex: 127.0.0.1)
    		return !string.IsNullOrEmpty (userIP) && Regex.IsMatch (userIP, "^127");
    	}
    }

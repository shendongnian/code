    public static class ContextWrapper2
    {
    	public static bool IsIis7IntegratedAppStart { get; set; }
    
    	public static HttpRequest Request
    	{
    		get
    		{
    			if (ContextWrapper2.IsIis7IntegratedAppStart) return null;
    			HttpContext context = HttpContext.Current;
    			if (context == null) return null;
    
    			return context.Request;
    		}
    	}
    }

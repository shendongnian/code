    public static class ContextWrapper2
    {
    	public static bool IsIis7IntegratedAppStart { get; set; }
    
    	public static HttpRequest Request
    	{
    		get
    		{
    			HttpContext context = HttpContext.Current;
    			if (context == null) return null;
    
    			if (ContextWrapper2.IsIis7IntegratedAppStart)
    			{
    				try { return context.Request; }
    				catch (HttpException e) { /* Consume or log e*/ return null; }
    				// Do not use message comparison - .NET translates messages for multi-culture environments.
    			}
    
    			return context.Request;
    		}
    	}
    }

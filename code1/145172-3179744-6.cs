    public static class ContextWrapper
    {
    	// Set automatically in a static constructor or let the user specify in Application_Start.
    	public static bool IsIis7 { get; set; }
    
    	public static HttpRequest Request
    	{
    		get
    		{
    			HttpContext context = HttpContext.Current;
    			if (context == null) return null;
    
    			if (HttpRuntime.UsingIntegratedPipeline && ContextWrapper.IsIis7)
    			{
    				try { return context.Request; }
    				catch (HttpException e) { /* Consume or log e*/ return null; }
    				// Do not use message comparison - .NET translates messages for multi-culture environments.
    			}
    
    			return context.Request;
    		}
    	}
    }

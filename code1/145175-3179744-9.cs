    public static class ContextWrapper
    {
    	public static HttpRequest Request
    	{
    		get
    		{
    			HttpContext context = HttpContext.Current;
    			if (context == null) return null;
    
    			if (HttpRuntime.UsingIntegratedPipeline)
    			{
    				try { return context.Request; }
    				catch (HttpException e) { /* Consume or log e*/ return null; }
    				// Do not use message comparison - .NET translates messages for multi-culture environments.
    			}
    
    			return context.Request;
    		}
    	}
    }

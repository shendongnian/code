    public intefrace IVariableHandlerFactory
    {
        IVariableHandler Get(string description);
    }
    public class VariableHandlerFactory : IVariableHandlerFactory
    {
	    private readonly IDictionary<string, IVariableHandler> _cache;
	
    	public VariableHandlerFactory()
	    {
    		_cache = new Dictionary<string, IVariableHandler>();
    	}
	
    	public IVariableHandler Get(string description)
	    {
	    	IVariableHandler handler; 
	
    		if(_cache.TryGetValue(description, out handler))
    		{
    			return handler;			
    		}
		
		    handler = //create it...
		    _cache[description] = handler;
		  
		    return handler;
    	}
    }

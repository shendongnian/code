    public abstract class HandlerBase <T> where T : TEvent, new()
    {
    	public abstract void Handle(T evt);
    
    
    	public void Handle(TEvent evt)
    	{
    		if (!(evt is T))
    		{
    			throw new ArgumentException("This handler does not support the event type " + evt.GetType().FullName); 
    		}
    
    		Handle((T) evt);
    	}
    }

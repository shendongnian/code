    public class Context
    {	
    	public IDisposable ReadUnCommitted()
    	{
    		SetReadUnCommitted();
    		return Disposable.Create(PutBackOriginalIsolationLevel);
    	}
    }

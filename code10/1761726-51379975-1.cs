    class MyObj : IDisposable
    {
    	public void Dispose()
    	{
    	   // Dispose of unmanaged resources.
    	   Dispose(true);
    	   // Suppress finalization.
    	   GC.SuppressFinalize(this);
    	}	
    }

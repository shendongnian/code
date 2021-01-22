    class MyClass : IDisposable 
    {
    	// ...
	#region IDisposable Members and Helpers
	private bool disposed = false;
	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}
	private void Dispose(bool disposing)
	{
		if (!this.disposed)
		{
			if (disposing)
			{
				// cleanup code goes here
			}
			disposed = true;
		}
	}
	~MyClass()
	{
		Dispose(false);
	}
	#endregion
    }

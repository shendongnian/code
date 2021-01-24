    public static class DisposableEx
    {
    	public static IDisposable Create(Action dispose)
    	{
    		return new DisposableImpl(dispose);
    	}
    
    	private class DisposableImpl : IDisposable
    	{
    		private readonly Action dispose;
    		
    		public DisposableImpl(Action dispose)
    		{
    			this.dispose = dispose;
    		}
    		
    		public void Dispose() => dispose?.Invoke();
    	}
    }
 

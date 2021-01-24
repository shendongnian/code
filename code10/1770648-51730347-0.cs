	xs.Subscribe(x => Console.WriteLine(x), Stubs.Throw, Stubs.Nop);
    public static class Stubs
    {
    	
    	public static readonly Action Nop = delegate
    	{
    	};
    
    	public static readonly Action<Exception> Throw = delegate (Exception ex)
    	{
    		var edi = ExceptionDispatchInfo.Capture(ex);
    		edi.Throw();
    	};
    }

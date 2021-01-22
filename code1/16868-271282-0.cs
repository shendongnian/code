    public class Proxy
    {
    	private bool _isOpen;
    
    	public event EventHandler Complete;
    
    	public void Close() 
    	{
    		_isOpen = false;
    	}
    
    	public void Open() 
    	{ 
    		_isOpen = true; 
    	}
    
    	public void RemoteOperationAsync()
    	{
    		if (!_isOpen)
    			throw new ApplicationException();
    		Thread.Sleep(1000);
    		if (Complete != null)
    			Complete(this, EventArgs.Empty);
    	}
    }
    public static class Program
    {
    	public static void Main()
    	{
    		WeakReference wr = null;
    
    		{
    			var proxy = new Proxy();
    			proxy.Complete += (sender, e) =>
    				{
    					proxy.Close();
    					wr = new WeakReference(proxy);
    					proxy = null;
    				};
    			proxy.Open();
    			proxy.RemoteOperationAsync();
    		}
    
    		GC.Collect(GC.GetGeneration(wr));
    		GC.WaitForPendingFinalizers();
    
    		Console.WriteLine("[LAMBDA] Is WeakReference alive? " + wr.IsAlive);
    	}
    }

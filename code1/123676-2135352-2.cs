    public class ThreadSafeClass
    {
    	public double PropertyA { get; set; }
    	public double PropertyB { get; set; }
    	public double PropertyC { get; set; }
    
    	private ThreadSafeClass()
    	{
    
    	}
    
    	public void ModifyClass()
    	{
    		// do stuff
    	}
    
    	public class Synchronizer
    	{
    		private ThreadSafeClass instance = new ThreadSafeClass();
    		private readonly object locker = new object();
    
    		public void Execute(Action<ThreadSafeClass> action)
    		{
    			lock (locker)
    			{
    				action(instance);
    			}
    		}
            public T Execute<T>(Func<ThreadSafeClass, T> func)
    		{
    			lock (locker)
    			{
    				return func(instance);
    			}
    		}
    	}
    }

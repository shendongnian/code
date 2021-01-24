    public SomeClass{
    	public static ConcurrentDictionary<Thread, HttpContextData> HttpContextData 
    		= new ConcurrentDictionary<Thread, HttpContextData>();
    }
    
    // class to hold HttpContext related data
    class HttpContextData { ... }
    
    
    // somewhere in Asp.Net app...
    ThreadStart fireAndForgetFunc = () =>
    {
        var data = SomeClass.HttpContextData.GetValueOrDefault(Thread.CurrentThread);
        // work with HttpContextData
    };
    
    fireAndForgetFunc += () => 
    {  
        // adding a cleanup
        SomeClass.HttpContextData.TryRemove(Thread.CurrentThread, out HttpContextData data); 
    };
    Thread t = new Thread(fireAndForgetFunc);
    
    var httpContextData = new HttpContextData() {};
    SomeClass.HttpContextData.TryAdd(t, httpContextData);
    t.Start();

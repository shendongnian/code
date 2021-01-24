    private Base TryChangeType(Base instance)
    {
    	var d = new Derived();
    	instance = d;
    	
    	Console.WriteLine(instance.GetType().ToString());
    	
    	return instance;
    }
    
    private void CallChangeType()
    {
    	var b = new Base();
    	b = TryChangeType(b);
    	Console.WriteLine(b.GetType().ToString());
    }

    public object MyMethod() 
    {
    	return new
        {
             Property1 = "test",
            Property2 = "test"
         };
    }
    static void Main(..)
    {
    	dynamic o = MyMethod();  
    	var p1 = o.Property1;
    	var p2 = o.Property2;
    }

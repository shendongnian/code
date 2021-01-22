    class Example
    {
    	static Object obj = new Object();
    
    	static int Foo()
    	{
    		lock (obj)
    		{
    			Console.WriteLine("Foo");
    			return 1;
    		}
    	}
    
    	static int Bar()
    	{
    		lock (obj)
    		{
    			Console.WriteLine("Bar");
    		}
    		return 2;
    	}
    }

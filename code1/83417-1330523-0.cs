    class Test
    {
    	static Object fooLock = new Object();
    	static String foo;
    
    	public static String Foo
    	{
    		get { return foo; }
    		set
    		{
    			lock (fooLock)
    			{
    				foo = value;
    			}
    		}
    	}
    }

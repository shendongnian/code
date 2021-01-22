    class CMyClass
    {
    	public void FunctionToCall( int a, int b, int c )
    	{
    		// This is the callback
    	}
    
    	public static void Foo()
    	{
    		FooCallbackType myDelegate = new FooCallbackType(
    			this.FunctionToCall );
    		// Now you can pass that to the function
    		// that needs to call you back.
    	}
    }

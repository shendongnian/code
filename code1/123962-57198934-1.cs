	public static void StaticFunctionToCall( int a, int b, int c )
	{
		// This is the callback
	}
	public static void Foo()
	{
		FooCallbackType myDelegate = new FooCallbackType(
			CMyClass.StaticFunctionToCall );
	}

    using System;
    
    class Foo<T> { }
    
    class Program
    {
    	static void Main()
    	{
    		myMethod(new Foo<String>());
    	}
    
    	private static void myMethod<T>(Foo<T> foo)
    	{
    		// use the T parameter in here
    	}
    }

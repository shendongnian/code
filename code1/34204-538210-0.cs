    using System;
    
    class Program
    {
    	static void Main()
    	{
    		Foo foo = (Foo)create("Foo", new Object[] { });
    		Bar bar = (Bar)create("Bar", new Object[] { "hello bar" });
    		Baz baz = (Baz)create("Baz", new Object[] { 2, "hello baz" });
    	}
    
    	static Object create(String typeName, Object[] parameters)
    	{
    		return Activator.CreateInstance(Type.GetType(typeName), parameters);
    	}	
    }
    
    class Foo
    {
    	public Foo() { }
    }
    
    class Bar
    {
    	public Bar(String param1) { }
    }
    
    class Baz
    {
    	public Baz(Int32 param1, String param2) { }
    }

    using System;
    using System.Reflection;
    
    class Test
    {
    	static void Main()
    	{
    		Foo foo = new Foo();
    		typeof(Foo).GetProperty("Bar")
    			.SetValue(foo, 1234, null);
    	}
    }
    
    class Foo
    {
    	public Nullable<Int32> Bar { get; set; }
    }

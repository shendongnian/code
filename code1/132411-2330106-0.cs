    using System;
    using System.Reflection;
    
    class Example
    {
    	static void Main()
    	{
    		var field = typeof(Foo).GetField("bar", 
                                BindingFlags.Static | 
                                BindingFlags.NonPublic);
    
            // Normally the first argument to "SetValue" is the instance
            // of the type but since we are mutating a static field we pass "null"
    		field.SetValue(null, "baz");
    	}
    }
    
    static class Foo
    {
    	static readonly String bar = "bar";
    }

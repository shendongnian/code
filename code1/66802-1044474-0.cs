    using System;
    using System.Reflection;
    
    class Program
    {
    	static void Main()
    	{
    		Type t = Type.GetType("Foo");
    		MethodInfo method 
                 = t.GetMethod("Bar", BindingFlags.Static | BindingFlags.Public);
    		method.Invoke(null, null);
    	}
    }
    
    class Foo
    {
    	public static void Bar()
    	{
    		Console.WriteLine("Bar");
    	}
    }

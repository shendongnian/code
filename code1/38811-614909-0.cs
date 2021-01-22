    using System;
    using System.Reflection;
    
    class Program
    {
    	static void Main()
    	{
    		Type type = Type.GetType("Foo");
    		MethodInfo info = type.GetMethod("Bar");
    
    		Console.WriteLine(info.Invoke(null, null));
    	}
    }
    
    static class Foo
    {
    	public static String Bar() { return "Bar"; }
    }

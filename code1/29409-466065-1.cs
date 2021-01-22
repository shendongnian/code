    using System;
    using System.Reflection;
    
    class Foo
    {
    	public static void Main()
    	{
    		var type = typeof(Foo);
    		var reflectionLoadType = Assembly.ReflectionOnlyLoad("ConsoleApplication1").GetType("Foo");
    		Console.WriteLine(type == reflectionLoadType);  //false
    		Console.WriteLine(type.Equals(reflectionLoadType));  //false
    
    		Console.WriteLine("DONE");
    		Console.ReadKey();
    	}
    }

    using System;
    using System.Reflection;
    
    class Example
    {
    	static void Main()
    	{
    		Assembly assembly = Assembly.LoadFrom(@"Test.exe");
    
    		Type reflectedType = assembly.GetType("Example");
    		Type knownType = typeof(Example);
    
    		Console.WriteLine(reflectedType == knownType);
    	}
    }

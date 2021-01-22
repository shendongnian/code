    using System;
    using System.Reflection;
    
    class Program
    {
    	static void Main()
    	{
    		caller("Foo", "Bar");
    	}
    
    	static void caller(String myclass, String mymethod)
    	{
    		// Get a type from the string 
    		Type type = Type.GetType(myclass);
    		// Create an instance of that type
    		Object obj = Activator.CreateInstance(type);
    		// Retrieve the method you are looking for
    		MethodInfo methodInfo = type.GetMethod(mymethod);
    		// Invoke the method on the instance we created above
    		methodInfo.Invoke(obj, null);
    	}
    }
    
    class Foo
    {
    	public void Bar()
    	{
    		Console.WriteLine("Bar");
    	}
    }

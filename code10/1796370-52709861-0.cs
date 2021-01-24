    void Main()
    {
    	var parameterCount = typeof(Test).GetMethod("Foo").GetParameters().Count();
    	Console.WriteLine(parameterCount); // Output: 2
    }
    
    // Define other methods and classes here
    public static class Test 
    {
    	public static void Foo(double x, params double[] y) 
        {}
    }

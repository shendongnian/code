    using System;
    using BenchmarkHelper;
    
    class Program
    {
    	static void Main()
    	{
    		Object input = "Foo";
    		String output = "Foo";
    
    		var results 
               = TestSuite.Create("Casting vs. virtual method", input, output)
    		    .Add(cast)
    		    .Add(tos)
    		    .RunTests()
    		    .ScaleByBest(ScalingMode.VaryDuration);
    
    		results.Display(ResultColumns.NameAndDuration | ResultColumns.Score,
    				results.FindBest());
    	}
    
    	static String cast(Object o)
    	{
    		return (String)o;
    	}
    
    	static String tos(Object o)
    	{
    		return o.ToString();
    	}
    }

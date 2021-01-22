    using System;
    using BenchmarkHelper;
    
    class Program
    {
    	static void Main()
    	{
    		Object input = "test";
    		String output = "test";
    
    		var results = TestSuite.Create("Casting", input, output)
    		    .Add(cast)
    		    .Add(asCast)
    		    .RunTests()
    		    .ScaleByBest(ScalingMode.VaryDuration);
    		results.Display(ResultColumns.NameAndDuration | ResultColumns.Score,
    				results.FindBest());
    	}
    
    	static String cast(Object o)
    	{
    		return (String)o;
    	}
    
    	static String asCast(Object o)
    	{
    		return o as String;
    	}
    
    }

    using System;
    using BenchmarkHelper;
    
    class Example
    {
    	static void Main()
    	{
    		var results = TestSuite.Create
                    ("Boolean.TryParse vs. String comparison", "True", true)
    		    .Add(tryParse)
    		    .Add(stringComparison)
    		    .RunTests()
    		    .ScaleByBest(ScalingMode.VaryDuration);
    
    		results.Display(ResultColumns.NameAndDuration | ResultColumns.Score,
    				results.FindBest());		
    	}
    
    	static Boolean tryParse(String input)
    	{
    		Boolean result;
    		Boolean.TryParse(input, out result);
    		return result;
    	}
    
    	static Boolean stringComparison(String input)
    	{
    		return "True".Equals(input, StringComparison.OrdinalIgnoreCase); 
    	}
    }

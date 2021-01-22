    class Program
    {
    	const int __iterations = 10000000;
    
    	static void Main(string[] args)
    	{
    		TestStringBuilder();
    		Console.ReadLine();
    	}
    
    	public static void TestStringBuilder()
    	{
    		//potentially a collection with several hundred items:
    		var outputStrings = new [] { "test1", "test2", "test3" };
    
    		var stopWatch = new Stopwatch();
    
    		//Option #1
    		stopWatch.Start();
    		var formattedOutput = new StringBuilder();
    
    		for (var i = 0; i < __iterations; i++)
    		{
    			foreach (var outputString in outputStrings)
    			{
    				formattedOutput.Append("prefix ");
    				formattedOutput.Append(outputString);
    				formattedOutput.Append(" postfix");
    
    				var output = formattedOutput.ToString();
    				ExistingOutputMethodThatOnlyTakesAString(output);
    
    				//Clear existing string to make ready for next iteration:
    				formattedOutput.Remove(0, output.Length);
    			}
    		}
    		stopWatch.Stop();
    
    		Console.WriteLine("Option #1 ({1} iterations): {0}ms", stopWatch.ElapsedMilliseconds, __iterations);
                Console.ReadLine();
    		stopWatch.Reset();
    
    		//Option #2
    		stopWatch.Start();
    		for (var i = 0; i < __iterations; i++)
    		{
    			foreach (var outputString in outputStrings)
    			{
    				StringBuilder formattedOutputInsideALoop = new StringBuilder();
    
    				formattedOutputInsideALoop.Append("prefix ");
    				formattedOutputInsideALoop.Append(outputString);
    				formattedOutputInsideALoop.Append(" postfix");
    
    				ExistingOutputMethodThatOnlyTakesAString(
    				   formattedOutputInsideALoop.ToString());
    			}
    		}
    		stopWatch.Stop();
    
    		Console.WriteLine("Option #2 ({1} iterations): {0}ms", stopWatch.ElapsedMilliseconds, __iterations);
    	}
    
    	private static void ExistingOutputMethodThatOnlyTakesAString(string s)
    	{
    		// do nothing
    	}
    } 

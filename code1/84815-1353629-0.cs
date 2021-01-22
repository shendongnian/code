    abstract class Benchmark
    {
    	TimeSpan Run()
    	{
    		Stopwatch swatch = Stopwatch.StartNew();
    		// Optionally loop this several times and divide elapsed time by loops:
    		RunMethod();
    		swatch.Stop();
    		return swatch.Elapsed;
    	}
    
    	///<summary>Override this method with the code to be benchmarked.</summary>
    	protected abstract void RunMethod()
    	{
    	}
    }

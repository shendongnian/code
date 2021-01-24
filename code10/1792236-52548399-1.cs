    static void Main(string[] args)
    {
    	Console.WriteLine("Please enter your test scores");
    
    	var scores =
    		Enumerable
    			.Repeat(0, int.MaxValue)
    			.Select(x => TryParse(Console.ReadLine()))
    			.TakeWhile(x => x.HasValue)
    			.ToArray();
    			
    	if (scores.Length > 0)
    	{
    		Console.WriteLine("The average of your test score is : {0}", scores.Average());
    	}
    }
    
    static double? TryParse(string text)
    {
    	double? result = null;
    	if (double.TryParse(text, out double parsed))
    	{
    		result = parsed;
    	}
    	return result;
    }

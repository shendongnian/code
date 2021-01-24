    static void Main(string[] args)
    {
    	Console.WriteLine("Please enter your first test score");
    
    	double? testScore = TryParse(Console.ReadLine());
    	double? sum = 0.0;
    	int counter = 0;
    
    	while (testScore.HasValue)
    	{
    		sum += testScore;
    		counter++;
    
    		Console.WriteLine("Please enter your another test score");
    		testScore = TryParse(Console.ReadLine());
    	}
    
    	if (counter > 0)
    	{
    		Console.WriteLine("The average of your test score is : {0}", sum / counter);
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

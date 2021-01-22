    public static void AreSimilar(DateTime expected, DateTime actual, TimeSpan tolerance, string message)
    {
    	DateTime expectedMin = expected.Subtract(tolerance);
    	DateTime expectedMax = expected.Add(tolerance);
    
    	if (actual < expectedMin || actual > expectedMax)
    	{
    		throw new AssertFailedException(message);
    	}
    }

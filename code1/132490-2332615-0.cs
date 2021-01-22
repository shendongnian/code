    public static void Main(string[] args)
    {
    	int retries = 0;
    	bool success = false;
    	int maxRetries = 3;
    	string fileName = args[0];
    	
    	Console.Write("Checking data ";
    	
    	while(!success && retries++ < maxRetries)
    	{
    		Console.Write("{0}...", retries);
    		success = File.Exists(fileName);
    	}
    	Console.WriteLine(" {0}Found!", (success ? "" : "Not ") );
    }

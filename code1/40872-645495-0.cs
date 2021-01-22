    int i;
    // TryParse() returns true/false depending on whether userInput is an int
    
    if (int.TryParse(userInput, out i))
    {
    	if (i > 100)
    	{
    		Console.WriteLine("I hate myself");
        }
    	else
    	{
    		Console.WriteLine("I love myself");
    	}
    }
    else
    {
    	Console.WriteLine("Input was not a valid number.");
    }

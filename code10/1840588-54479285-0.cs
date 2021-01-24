    do
    {
    	Console.WriteLine("Please enter magical number or enter exit to stop");
    	string enteredNumber = Console.ReadLine()?.Trim();
		if ("exit".Equals(enteredNumber, StringComparison.InvariantCultureIgnoreCase))
    	{
    		break; 
    	}
    
    	bool valid = int.TryParse(enteredNumber, out int number);
    	while (!valid)
    	{
    		Console.WriteLine("Please enter a valid integer");
    		valid = int.TryParse(Console.ReadLine()?.Trim(), out number);
    	}
    
    	if (number > 0)
    	{
    		for (int i = 1; i <= number; i++)
    		{
    			Console.Write("{0}, ", i);
    		}
    	}
    	else
    	{
    		Console.WriteLine("Wow that number is too low for me!");
    	}
    } while (true);

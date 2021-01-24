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
			Console.WriteLine(string.Join(", ", Enumerable.Range(1, number)));
		}
		else
		{
			Console.WriteLine("Wow that number is too low for me!");
		}
    } while (true);

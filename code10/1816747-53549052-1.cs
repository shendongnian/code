	List<int> elements = new List<int>();
	
	do
	{
		Console.WriteLine("Please enter an integer.");
		
		if (int.TryParse(Console.ReadLine().Trim(), out int result))
		{
			Console.WriteLine($"You entered the integer {result}");
			elements.Add(result);
		}
		else
		{
			Console.WriteLine("You must enter an integer. Please try again.");
		}
	} while (elements.Count < 10);

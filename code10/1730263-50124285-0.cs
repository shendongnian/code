	var input = Console.ReadLine();
	if (int.TryParse(input, out var value))
	{
		if (1 <= value && value <= 7)
		{
			Console.WriteLine("The day you picked was {0}", (EDay)value - 1);
		}
		else
		{
			Console.WriteLine("PLease enter an number between 1 - 7");
		}
	}
	else
	{
		Console.WriteLine("Please enter an actual numerical day of the week.");
	}

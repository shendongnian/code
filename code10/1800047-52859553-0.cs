    int? num = null;
	while(!num.HasValue)
	{
		Console.WriteLine("Please enter an integer:");
		num = int.TryParse(Console.ReadLine(), out int i) ? i : new int?();
	}
	Console.WriteLine("Entered integer: " + num.Value);

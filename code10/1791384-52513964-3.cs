	while (number != 0)
	{
		Console.Write("Enter a number: ");
		number = int.Parse(Console.ReadLine());
		if (number > 0 )
		{
			counter++;
			if (counter % 5 == 0)
			{
				sum = sum + number;
			}
		}
		else
		{
			Console.Write("Please no negative numbers!");
		}
	}

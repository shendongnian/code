	int age;
	if (int.TryParse(Console.ReadLine(), out age))
	{
	    if (age > 17)
	    {
	        Console.WriteLine("That's too bad! You will have to wait until next year!");
	    }
	    // etc
	}
	else
	{
	    Console.WriteLine("Please enter a valid input");
	}

    if (int.TryParse(Console.ReadLine().Trim(), out int element))
    {
	    Console.WriteLine($"You entered the integer {element}");
    }
    else
    {
     	Console.WriteLine("You must enter an integer. Please try again.");
    }

    int age;
    do {
    	Console.Write("Please enter the persons age: ");
    
    	if (!int.TryParse(Console.ReadLine(), out age))
    		break;
       
    	if (age == 17)
    	{
    		Console.WriteLine("That's to bad! You will have to wait until next year!");
    	}
    	else if (age < 18)
    	{
    		Console.WriteLine("That's to bad! You will have to wait a couple years until you can come in!");
    	}
    	else
    	{
    		Console.WriteLine("You are of age to be here.");
    	}
    }
    while (true);

    Console.WriteLine("What is your name, traveler?");
    string mainName = Console.ReadLine();
    Console.WriteLine("So, your name is " + mainName + " ? y/n");
    do
    {
    	var ans = Console.ReadKey(true).Key;
    	if (ans == ConsoleKey.Y)
    	{
    		Console.WriteLine("Nice, let me introduce myself now.");
    		break;
    	}
    	else if (ans == ConsoleKey.N)
    	{
    		break;
    	}
    	Console.WriteLine("Please insert either y or n.");
    } while (true);

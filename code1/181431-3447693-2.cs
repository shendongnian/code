        var c = Console.ReadKey();
        Console.WriteLine();
        Console.WriteLine(c.Key.ToString());
        // Prints
        //a
        //A
        switch(c.Key)
        {
            case ConsoleKey.D0:
                //User entered 0
                Console.WriteLine("Exiting...");
                break;
            case ConsoleKey.D1:
                //User entered 1
                Console.WriteLine("You chose to create a new file!");
                break;
            case ConsoleKey.D2:
                //User entered 2
                Console.WriteLine("You chose to open a file!");
                break;
            case ConsoleKey.D3:
                //User entered 3
                Console.WriteLine("You chose to edit an existing file!");
                break;
            default:
                Console.WriteLine("No response for that key");
                break;
        }
        Console.ReadLine();

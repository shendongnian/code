    // An endless loop, until the user enters a valid command, when we break or exit.
    while (true)
    {
        Console.Write("Type 'start' to begin, or 'quit' to exit: ");
        string input = Console.ReadLine();
        if (input.Equals("start", StringComparison.OrdinalIgnoreCase))
        {
            // They entered 'start', so we can exit the loop and start our code
            Console.WriteLine("Program starting!");
            break; // This exits the 'while' loop, and the program continues
        }
        if (input.Equals("quit", StringComparison.OrdinalIgnoreCase))
        {
            // Exit the program (the whole program quits so we don't need a break
            Environment.Exit(0);
        }
        else
        {
            // Let them know the input was invalid, and the loop will continue
            Console.WriteLine("That is not a recognized command, please try again");
        }
    }
    // Code execution will continue here if they type "start"
    Console.Write("\nDone! Press any key to exit...");
    Console.ReadKey();

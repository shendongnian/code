    while(true)
    {
        Console.Write("> ");
        var command = Console.ReadLine();
        if (command == "about") {
            Console.WriteLine("This Operational System was build with Cosmos using C#");
            Console.WriteLine("Emerald OS v0.01");
        } else if (command == "exit") {
            break; // Exit loop
        }
    }

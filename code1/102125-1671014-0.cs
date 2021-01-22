    while(true) {    //Loop forever
        string command = Console.ReadLine();
        if (command.Equals("Exit", StringComparison.OrdinalIgnoreCase))
            break;    //Get out of the infinite loop
        else if (command.Equals("About", StringComparison.OrdinalIgnoreCase)) {A
            Console.WriteLine("This Operational System was build with Cosmos using C#");
            Console.WriteLine("Emerald OS v0.01");
        }
        //...
    }

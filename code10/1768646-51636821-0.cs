    Console.TreatControlCAsInput = true;     
    var key = Console.ReadKey();
    if ((key.Modifiers & ConsoleModifiers.Alt) != 0)
    {
        key = Console.ReadKey();
        if (key.Key == ConsoleKey.K)
        {
           Console.WriteLine("killing console");
           System.Environment.Exit(0);
        }
    }
    else
    {
     //your other logic, remember that you already read the first key
    }

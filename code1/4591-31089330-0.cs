    Console.WriteLine("Press any key during the next 2 seconds...");
    Thread.Sleep(2000);
    if (Console.KeyAvailable)
    {
        Console.WriteLine("Key pressed");
    }
    else
    {
        Console.WriteLine("You were too slow");
    }

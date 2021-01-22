    int minutes = 1;
    while (true)
    {
       if (Console.KeyAvailable)
       {
            ConsoleKeyInfo c = Console.ReadKey(true);
    	if (c.Key == ConsoleKey.Enter)
    	{
              	break;
    	}
       }
       Thread.Sleep(1000);
       if (minutes++ > 10)
       {
    	throw;
       }
    }

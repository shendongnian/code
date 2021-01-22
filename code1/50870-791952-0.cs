    private static bool WaitForRestart()
    {
        while (true)
        {
            // clear users input
            Console.CursorLeft = 0;
            Console.Write(' ');
            Console.CursorLeft = 0;
    
            // read users input
            var key = Console.ReadKey();
            if ((key.Modifiers & ConsoleModifiers.Control) != 0
                && key.Key == ConsoleKey.R)
            {
                // refersh the settings
                ConfigurationManager.RefreshSection("appSettings");
                return true;
            }
            if (key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Escape)
            {
                return false;
            }
        }
    }

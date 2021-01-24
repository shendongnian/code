        while (!(NextKey.Key == ConsoleKey.DownArrow ||
                NextKey.Key == ConsoleKey.UpArrow ||
                NextKey.Key == ConsoleKey.Q ||
                NextKey.Key ==  ConsoleKey.Enter))
        {
            NextKey = Console.ReadKey();
        }
        switch (NextKey.Key)
        {
            case ConsoleKey.Enter:
                // Do something depending on Selected option
                switch (Selected)
                {
                    case 1:
                        // Do something
                        break;
                    case 2:
                        // Do something
                        break;
                    case 3:
                        // Do something
                        break;
                }
                break;
            case ConsoleKey.DownArrow:
            ...

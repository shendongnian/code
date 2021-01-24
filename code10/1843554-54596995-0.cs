    // This is the code that the thread runs
    // Memory class contains all stored values for this program
    private static void GetKeyboardInput(Memory memory)
    {
        while (true)
        {
            var key = Console.ReadKey().Key;
            if (key == ConsoleKey.Enter)
            {
                break;
            }
            else if (key == ConsoleKey.UpArrow)
            {
                // move up. There is more code here but not relevant
                // meaning these values effect the animation and nothing else
            }
            else if (key == ConsoleKey.DownArrow)
            {
                // Move Down. Same as before
            }
        }
        // No need to call Thread.Abort - exiting this method does the same
    }

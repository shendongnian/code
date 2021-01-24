    private static int GetMenuChoice(string header, List<string> options, char cursor = '>')
    {
        // Clear console and hide cursor
        Console.Clear();
        Console.CursorVisible = false;
        // Write our header with an underline
        Console.WriteLine("   " + header);
        Console.WriteLine("   " + new string('-', header.Length));
        Console.WriteLine();
        // Write out each option with spaces before it
        options.ForEach(option => Console.WriteLine($"   {option}"));
        // Move to the first option and, from the second character,
        // write a backspace and then the cursor symbol
        Console.SetCursorPosition(1, 3);
        Console.Write($"\b{cursor}");
        // Move cursor when user presses arrow keys, and get selection when they press enter
        while (true)
        {
            // Pass 'true' to ReadKey so the input is not written
            var input = Console.ReadKey(true);
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    if (Console.CursorTop > 3)
                    {
                        Console.CursorLeft = 1;
                        Console.Write("\b ");
                        Console.SetCursorPosition(1, Console.CursorTop - 1);
                        Console.Write($"\b{cursor}");
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (Console.CursorTop < options.Count + 2)
                    {
                        Console.CursorLeft = 1;
                        Console.Write("\b ");
                        Console.SetCursorPosition(1, Console.CursorTop + 1);
                        Console.Write($"\b{cursor}");
                    }
                    break;
                case ConsoleKey.Enter:
                    var selection = Console.CursorTop - 3;
                    Console.CursorVisible = true;
                    Console.SetCursorPosition(0, options.Count + 4);
                    return selection;
            }
        }
    }

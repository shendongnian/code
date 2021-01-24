    private static int GetMenuChoice(List<string> options, char cursor = '>')
    {
        Console.Clear();
        Console.CursorVisible = false;
        // Write options and put the cursor in front of the first one
        options.ForEach(option => Console.WriteLine($"   {option}"));
        Console.SetCursorPosition(1, 0);
        Console.Write($"\b{cursor}");
        while (true)
        {
            // Pass true to ReadKey so the input is not written
            var input = Console.ReadKey(true);
            // When an arrow key is pressed, backspace and space to erase the cursor 
            // in the current row, move up or down, and then backspace and write the cursor
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    if (Console.CursorTop > 0)
                    {
                        Console.CursorLeft = 1;
                        Console.Write("\b ");
                        Console.SetCursorPosition(1, Console.CursorTop - 1);
                        Console.Write($"\b{cursor}");
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (Console.CursorTop < options.Count - 1)
                    {
                        Console.CursorLeft = 1;
                        Console.Write("\b ");
                        Console.SetCursorPosition(1, Console.CursorTop + 1);
                        Console.Write($"\b{cursor}");
                    }
                    break;
                case ConsoleKey.Enter:
                    Console.CursorVisible = true;
                    return Console.CursorTop;
            }
        }
    }

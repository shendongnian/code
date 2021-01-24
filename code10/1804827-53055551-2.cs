    static string GetUserInput(string prompt, List<string> validResponses)
    {
        Console.Write(prompt);
        var inputCursorLeft = Console.CursorLeft;
        var inputCursorTop = Console.CursorTop;
        string input = Console.ReadLine();
        while (validResponses != null &&
               validResponses.Any() &&
               !validResponses.Contains(input, StringComparer.OrdinalIgnoreCase))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            // PadRight ensures that this line extends the width
            // of the console window so it erases itself each time
            Console.Write($"Error! '{input}' is not a valid response".PadRight(Console.WindowWidth));
            Console.ResetColor();
            Console.SetCursorPosition(inputCursorLeft, inputCursorTop);
            Console.Write(new string(' ', input.Length));
            Console.SetCursorPosition(inputCursorLeft, inputCursorTop);
            input = Console.ReadLine();
        }
        // Erase the last error message
        Console.Write(new string(' ', Console.WindowWidth));
        return input;
    }

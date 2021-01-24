    static string GetUserInput(string prompt, List<string> validResponses)
    {
        Console.Write(prompt);
        var inputCursorLeft = Console.CursorLeft;
        var inputCursorTop = Console.CursorTop;
        string input = string.Empty;
        while (true)
        {
            input = Console.ReadLine();
            if (validResponses == null || !validResponses.Any() ||
                validResponses.Contains(input, StringComparer.OrdinalIgnoreCase))
            {
                break;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"Error! '{input}' is not a valid response".PadRight(Console.WindowWidth));
            Console.ResetColor();
            Console.SetCursorPosition(inputCursorLeft, inputCursorTop);
            Console.Write(new string(' ', input.Length));
            Console.SetCursorPosition(inputCursorLeft, inputCursorTop);
        }
        // Erase the last error message if there was one
        Console.Write(new string(' ', Console.WindowWidth));
        return input;
    }

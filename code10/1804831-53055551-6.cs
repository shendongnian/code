    static string GetUserInput(string prompt, List<string> validResponses)
    {
        Console.Write(prompt);
        
        // Capture the cursor position just after the prompt
        var inputCursorLeft = Console.CursorLeft;
        var inputCursorTop = Console.CursorTop;
        // Now get user input
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
            // Set cursor position to just after the promt again, write
            // a blank line, and reset the cursor one more time
            Console.SetCursorPosition(inputCursorLeft, inputCursorTop);
            Console.Write(new string(' ', input.Length));
            Console.SetCursorPosition(inputCursorLeft, inputCursorTop);
            input = Console.ReadLine();
        }
        // Erase the last error message (if there was one)
        Console.Write(new string(' ', Console.WindowWidth));
        return input;
    }

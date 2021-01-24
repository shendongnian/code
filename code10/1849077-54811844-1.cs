    private static int GetIntFromUser(string prompt)
    {
        int result;
        var cursorTop = Console.CursorTop;
        do
        {
            // Set the cursor to the beginning of the line,
            // write a blank line, and set it to the beginning again
            Console.SetCursorPosition(0, cursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursorTop);
            Console.Write(prompt);
        } while (!int.TryParse(Console.ReadLine(), out result));
        return result;
    }

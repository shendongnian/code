    private static ConsoleKeyInfo GetKeyFromUser(string prompt)
    {
        Console.Write(prompt);
        var key = Console.ReadKey();
        Console.WriteLine();
        return key;
    }
    private static string GetStringFromUser(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }
    public static int GetIntFromUser(string prompt = null)
    {
        int input;
        int row = Console.CursorTop;
        int promptLength = prompt?.Length ?? 0;
        do
        {
            Console.SetCursorPosition(0, row);
            Console.Write(prompt + new string(' ', Console.WindowWidth - promptLength - 1));
            Console.CursorLeft = promptLength;
        } while (!int.TryParse(Console.ReadLine(), out input));
        return input;
    }

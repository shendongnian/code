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

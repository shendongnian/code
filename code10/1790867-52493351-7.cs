    private static void DrawLetter(string[] letter)
    {
        var top = Console.CursorTop;
        var left = Console.CursorLeft;
        var width = letter.Max(line => line.Length);
        foreach (var line in letter)
        {
            Console.Write(line);
            Console.SetCursorPosition(left, ++Console.CursorTop); // <- Increment top here
        }
        Console.SetCursorPosition(left + width + 1, top);
    }

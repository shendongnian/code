    private static void WriteColoredLines(string[] lines, Point start, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        for (int row = 0; row < lines.Length; row++)
        {
            Console.SetCursorPosition(start.X, start.Y + row);
            Console.Write(lines[row]);
        }
    }

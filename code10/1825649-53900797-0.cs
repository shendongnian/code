    public static void ColorAndWrite(ConsoleColor c1, ConsoleColor c2, string text)
    {
       Console.ForegroundColor = c1;
       Console.WriteLine(text);
       Console.ForegroundColor = c2;
    }

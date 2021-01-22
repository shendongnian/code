    public static class MyConsole
    {
        public static void WriteLine(this ConsoleColor Color, string Text)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(Text);   
        }
    }

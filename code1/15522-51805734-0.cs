    using FooConsole = System.Console;
    
    public static class Console
    {
        public static void WriteBlueLine(string text)
        {
            FooConsole.ForegroundColor = ConsoleColor.Blue;
            FooConsole.WriteLine(text);
            FooConsole.ResetColor();
        }
    }

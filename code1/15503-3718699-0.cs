    Console myConsole = null;
    myConsole.WriteBlueLine("my blue line");
        
    public static class Helpers {
        public static void WriteBlueLine(this Console c, string text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }

    public static class Console
    {       
        public static void WriteLine(String x)
        { System.Console.WriteLine(x); }
        public static void WriteBlueLine(String x)
        {
            System.Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.Write(.x);           
        }
    }

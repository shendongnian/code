    class Program
    {
        static void Main()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("White on blue.");
            Console.WriteLine("Another line.");
            Console.ResetColor();
        }
    }

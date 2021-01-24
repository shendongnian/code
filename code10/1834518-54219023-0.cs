    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("White on Blue.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("White on Red.");
            Console.ResetColor();
            Console.ReadLine();
        }
    }

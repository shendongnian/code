    internal class Program
    {
        private static void Main(string[] args)
        {
            Random r = new Random();
            while (true)
            {
                Console.ReadKey();
                int minLeft = Console.WindowLeft;
                int maxLeft = Console.WindowLeft + Console.WindowWidth;
                int minTop = Console.WindowTop;
                int maxTop = Console.WindowTop + Console.WindowHeight;
                Console.SetCursorPosition(r.Next(minLeft, maxLeft), r.Next(minTop, maxTop));
                // ...
            }
        }
    }

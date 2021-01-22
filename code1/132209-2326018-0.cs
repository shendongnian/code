    static void Main(string[] args)
    {
        Random rand = new Random();
        int maxShoots = 100;
        Console.Clear();
        for (int loop = 0; loop < maxShoots; loop++)
        {
            Console.CursorLeft = rand.Next(Console.WindowWidth);
            Console.CursorTop = rand.Next(Console.WindowHeight);
            Console.Write("x");
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            Console.Write("Iteration " + loop);
            Thread.Sleep(rand.Next(100));
        }
        Console.CursorLeft = 0;
        Console.CursorTop = Console.WindowHeight-1;
        Console.ReadKey();
    }

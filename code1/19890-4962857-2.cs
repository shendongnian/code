    static void Main(string[] args)
    {
        Console.BufferWidth = Console.WindowWidth = 100;
        Console.WindowHeight = 20;
        long lastticks = 0;
        while (true)
        {
            long diff = DateTime.UtcNow.Ticks - lastticks;
            if (diff == 0)
                Console.Write(".");
            else
                switch (diff)
                {
                    case 10000: case 10001: case 10002: Console.ForegroundColor=ConsoleColor.Red; Console.Write("1"); break;
                    case 20000: case 20001: case 20002: Console.ForegroundColor=ConsoleColor.Green; Console.Write("2"); break;
                    case 30000: case 30001: case 30002: Console.ForegroundColor=ConsoleColor.Yellow; Console.Write("3"); break;
                    default: Console.Write("[{0:0.###}]", diff / 10000.0); break;
                }
            Console.ForegroundColor = ConsoleColor.Gray;
            lastticks += diff;
        }
    }

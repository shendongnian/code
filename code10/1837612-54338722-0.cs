    static void Main(string[] args)
    {
        Console.Write("What will Donald eat?: ");
        Donald.Food = Console.ReadLine();
        Console.Write("Will Donald drink a slow potion?: ");
        Donald.Potion = Console.ReadLine();
        TakeDamage();
        SlowDown();
        PrintStats();
        // wait for user to exit
        Console.ReadLine();
        }

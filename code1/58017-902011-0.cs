    public static Object ConsoleLock = new Object();
    public static void Main(string[] args)
    {
        lock (ConsoleLock)
        {
            Console.WriteLine("Whatever");
        }
    }

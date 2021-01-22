    private readonly static object obj = new object();
    private static void Some(int number)
    {
        lock (obj)
        {
            RecurseSome(number);
        }
    }
    private static void RecurseSome(int number)
    {
        Console.WriteLine(number);
        RecurseSome(++number);
    }

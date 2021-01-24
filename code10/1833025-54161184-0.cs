    class Test
    {
        ~Test()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        var test = new Test();
        test = null;
        GC.Collect();
    }

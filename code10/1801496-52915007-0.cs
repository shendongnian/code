    static void Main(string[] args)
    {
        var sw = Stopwatch.StartNew();
        new Thread(() => { ExecuteAsyn("Thread", sw); }).Start();
        Console.WriteLine("Using Thread: " + sw.Elapsed);
        sw = Stopwatch.StartNew();
        Task g = Task.Factory.StartNew(() => ExecuteAsyn("TPL", sw));
        Console.WriteLine("Using TPL: " + sw.Elapsed);
        g.Wait();
        sw = Stopwatch.StartNew();
        g = Task.Factory.StartNew(() => ExecuteAsyn("TPL", sw));
        Console.WriteLine("Using TPL: " + sw.Elapsed);
        g.Wait();
        Console.ReadKey();
    }
    private static void ExecuteAsyn(string source, Stopwatch sw)
    {
        Console.WriteLine("Hello World! Using " + source + " the difference between initialization and execution is " + (sw.Elapsed));
    }

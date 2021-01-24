    static async Task Main(string[] args)
    {
        var schedulerPair = new ConcurrentExclusiveSchedulerPair(TaskScheduler.Default, 3);
        var factory = new TaskFactory(schedulerPair.ConcurrentScheduler);
        var tasks = new List<Task>();
        Random r = new Random();
        for (int i = 0; i < 5; i++)
        {
            var localI = i;
            var ts = TimeSpan.FromMilliseconds(1000 + r.Next(0, 10) * 100);
            var task = factory.StartNew(() => RunTask(localI, ts)).Unwrap();
            tasks.Add(task);
        }
        await Task.WhenAll(tasks);
    }
    static object mutex = new object();
    static int numberOfParallelWorkers;
    static async Task RunTask(int n, TimeSpan delay)
    {
        for (int i = 0; i < 2; i++)
        {
            int nw;
            lock (mutex) { nw = numberOfParallelWorkers = numberOfParallelWorkers + 1; }
            var start = DateTime.Now;
            Console.WriteLine($"Started task #{n} part {i} at {start:ss.ff}, tasks: {nw}");
            Thread.Sleep(delay); // simulate CPU-bound work
            lock (mutex) { nw = numberOfParallelWorkers = numberOfParallelWorkers - 1; }
            var end = DateTime.Now;
            Console.WriteLine($"Finished task #{n} part {i} at {end:ss.ff}, parallel: {nw}");
        }
        await Task.Yield();
    }

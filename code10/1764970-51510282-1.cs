    public static void Main()
    {
        List<String> list = new List<String>(Enumerable.Range(0,10000).Select(i=>i.ToString()));
        int maxThreads = 100;
        ThreadPool.SetMinThreads(maxThreads, maxThreads);
        int currentCount = 0;
        int maxCount = 0;
        object locker = new object();
        Parallel.ForEach(list, new ParallelOptions { MaxDegreeOfParallelism = maxThreads }, delegate (string url)
        {
            lock (locker)
            {
                currentCount++;
                maxCount = Math.Max(currentCount, maxCount);
            }
            Thread.Sleep(10);
            lock (locker)
            {
                maxCount = Math.Max(currentCount, maxCount);
                currentCount--;
            }
        });
        
        Console.WriteLine("Max Threads: " + maxCount); //Max Threads: 100
        Console.Read();
    }

    static void test()
    {
        ConcurrentQueue<int> queue = new ConcurrentQueue<int>(Enumerable.Range(1, 1000));
        int taskCount = Environment.ProcessorCount;
        Task[] tasks = new Task[taskCount];
        for (int taskIndex = 0; taskIndex < taskCount; taskIndex++)
        {
            Task task = Task.Factory.StartNew(() => IntensiveWorkTask(queue));
            tasks[taskIndex] = task;
        }
        Task.WaitAll(tasks);
    }
    private static void IntensiveWorkTask(ConcurrentQueue<int> queue)
    {
        while (queue.TryDequeue(out int value))
            IntensiveWork(value);
    }
    private static void IntensiveWork(int i)
    {
        Random r = new Random();
        Thread.Sleep(r.Next(i * 1));
    }

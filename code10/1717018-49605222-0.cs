    class Program
    {
        const int DELAY_TIME = 500;
        const int TASKS = 100;
        const int WAITS = 100;
        const int WARNING_THRESHOLD = 500;
        static void Main(string[] args)
        {
            using (Process p = Process.GetCurrentProcess())
            {
                p.PriorityClass = ProcessPriorityClass.RealTime;
                //ThreadPool.SetMinThreads(workerThreads: 200, completionPortThreads: 200);
                int workerThreads;
                int completionPortThreads;
                ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
                Console.WriteLine($"{workerThreads}, {completionPortThreads}");
                Console.WriteLine("*** Start...");
                Test();
                Console.WriteLine("*** Done!");
                Console.ReadKey();
            }
        }
        private static void Test()
        {
            int totalCount = 0;
            List<Task<int>> tasks = new List<Task<int>>();
            for (int taskId = 0; taskId < TASKS; taskId++)
            {
                //tasks.Add(DelaysWithStopWatchAsync(taskId)); // many delays
                tasks.Add(DelaysWithDateTimeAsync(taskId));  // no delays
            }
            Task.WaitAll(tasks.ToArray());
            foreach (var task in tasks)
            {
                totalCount += task.Result;
            }
            Console.WriteLine($"Total counts of deday = {totalCount}");
        }
        static async Task<int> DelaysWithStopWatchAsync(int taskId)
        {
            await Task.Yield();
            int count = 0;
            Stopwatch sw = new Stopwatch();
            for (int i = 0; i < WAITS; i++)
            {
                sw.Reset();
                sw.Start();
                await Task.Delay(DELAY_TIME).ConfigureAwait(false);   // (1)
                //Thread.Sleep(DELAY_TIME);   // (2)
                sw.Stop();
                Console.Write($"task({taskId})_iter({i}) elapsed={sw.ElapsedMilliseconds}");
                if (sw.ElapsedMilliseconds > DELAY_TIME + WARNING_THRESHOLD)
                {
                    Console.WriteLine($" *********** Too late!! ************");
                    count++;
                }
                else
                {
                    Console.WriteLine();
                }
            }
            return count;
        }
        static async Task<int> DelaysWithDateTimeAsync(int taskId)
        {
            await Task.Yield();
            int count = 0;
            for (int i = 0; i < WAITS; i++)
            {
                DateTime start = DateTime.Now;
                await Task.Delay(DELAY_TIME).ConfigureAwait(false);   // (1)
                //Thread.Sleep(DELAY_TIME);   // (2)
                DateTime end = DateTime.Now;
                int duration = (end - start).Milliseconds;
                Console.Write($"Task({taskId})_iter({i}) Elapsed={duration}");
                if (duration > DELAY_TIME + WARNING_THRESHOLD)
                {
                    Console.WriteLine($" *********** Too late!! ************");
                    count++;
                }
                else
                {
                    Console.WriteLine();
                }
            }
            return count;
        }
    }

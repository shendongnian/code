    public async Task asyncStartList()
    {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                Task[] tasks = emailingList.Select(s => SendEmail(s)).ToArray();
                Task.WaitAll(tasks);
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                Console.WriteLine("Time for completion " + elapsedTime);
                Console.ReadLine();
    }
    private static Task SendEmail(string s)
    {
        // Do send operation
    }

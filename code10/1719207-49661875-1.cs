    public async Task asyncStartList()
    {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                
                // option 1
                Task[] tasks = emailingList.Select(s => SendEmail(s)).ToArray();
                Task.WaitAll(tasks);
                // option 1 end
                // option 2
                Parallel.ForEach(emailingList, email =>
                                               {
                                                   // send email for 'email' variables
                                               });
               // option 2 end
               // option 3
               Parallel.For(0, emailingList.Length, i =>
                                               {
                                                   // send email for emailingList[i] variables
                                               });
               // option 3 end
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                Console.WriteLine("Time for completion " + elapsedTime);
                Console.ReadLine();
    }
    private Task SendEmail(string s)
    {
        // Do send operation
    }

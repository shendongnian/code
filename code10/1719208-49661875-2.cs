    public async Task asyncStartList()
    {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                
                // option 1
                Task[] tasks = emailingList.Select(s => Task.Run(() => { SendEmail(s); }).ToArray();
                Task.WaitAll(tasks);
                // option 1 end
                // option 2
                Parallel.ForEach(emailingList, email =>
                                               {
                                                   SendEmail(email);
                                               });
               // option 2 end
               // option 3
               Parallel.For(0, emailingList.Length, i =>
                                               {
                                                   SendEmail(emailingList[i]);
                                               });
               // option 3 end
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                Console.WriteLine("Time for completion " + elapsedTime);
                Console.ReadLine();
    }
    private void SendEmail(string emailAddress)
    {
        // Do send operation
    }

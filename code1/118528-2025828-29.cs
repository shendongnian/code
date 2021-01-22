        private static void Main() {
            // create timer to run RetrieveJob
            Timer timer = new Timer(RetrieveJob);
            // change timer to run RetrieveJob every 5 minutes
            timer.Change(TimeSpan.FromMinutes(0), TimeSpan.FromMinutes(5));
            // create thread to run ProcessJobs
            Thread thread = new Thread(ProcessJobs);
            thread.Run();
            // block main thread
            Console.ReadLine();
            // stop the timer
            timer.Change(Timeout.Infinite, Timeout.Infinite);
            // add 'null' job
            EnqueueJob(null);
            // wait until thread to run ProcessJobs has finished
            thread.Join();
        }

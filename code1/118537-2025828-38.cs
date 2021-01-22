        private static void Main() {
            // run RetrieveJob every 5 minutes using a timer
            Timer timer = new Timer(RetrieveJob);
            timer.Change(TimeSpan.FromMinutes(0), TimeSpan.FromMinutes(5));
            // run ProcessJobs in thread
            Thread thread = new Thread(ProcessJobs);
            thread.Start();
            // block main thread
            Console.ReadLine();
        }
    }

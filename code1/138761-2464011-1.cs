    class Program
    {
        public static void Main(string[] args)
        {
            var manager = new JobManager();
    
            manager.Start(() => Thread.Sleep(3500));
    
            while (true)
            {
                Console.WriteLine(manager.ActiveJobsCount);
    
                Thread.Sleep(250);
            }
        }
    }

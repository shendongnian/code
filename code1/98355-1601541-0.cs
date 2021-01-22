    static void Main(string[] args)
            {
                var stp = new SmartThreadPool((int) TimeSpan.FromMinutes(5).TotalMilliseconds,
                                              Environment.ProcessorCount - 1, Environment.ProcessorCount - 1);
                stp.Start();
                for (var i = 0; i < ClientCount; i++)
                {
                    stp.QueueWorkItem(PerformanceWorker);
                }
                stp.WaitForIdle();
                stp.Shutdown();
    
                return;
            }
 

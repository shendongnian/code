    private void test()
            {
                int cpuUsageIncreaseby = 10;
                while (true)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        //Console.WriteLine("am running ");
                        //DateTime start = DateTime.Now;
                        int cpuUsage = cpuUsageIncreaseby;
                        int time = 60000; // duration for cpu must increase for process...
                        List<Thread> threads = new List<Thread>();
                        for (int j = 0; j < Environment.ProcessorCount; j++)
                        {
                            Thread t = new Thread(new ParameterizedThreadStart(CPUKill));
                            t.Start(cpuUsage);
                            threads.Add(t);
                        }
                        Thread.Sleep(time);
                        foreach (var t in threads)
                        {
                            t.Abort();
                        }
    
                        //DateTime end = DateTime.Now;
                        //TimeSpan span = end.Subtract(start);
                        //Console.WriteLine("Time Difference (seconds): " + span.Seconds);
    
                        //Console.WriteLine("10 sec wait... for another.");
                        cpuUsageIncreaseby = cpuUsageIncreaseby + 10;
                        System.Threading.Thread.Sleep(20000);
                    }
                }
            }

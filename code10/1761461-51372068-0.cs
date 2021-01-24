    public static void Main()
    {
        //Add random list of processes (just testing with one for now)
        for (var i = 0; i < 1; i++)
        {
            processes.Add(1.ToString());
        }
        var sw = new Stopwatch();
        sw.Start();
        while (true)
        {
            foreach (var process in processes)
            {
                var currentProc = process;
                lock (padLock)
                {
                    if (!locks.ContainsKey(currentProc))
                    {
                        System.Threading.Tasks.Task.Factory.StartNew(() =>
                        {
                            if (!locks.ContainsKey(currentProc))
                            {
                                var lockObject = locks.GetOrAdd(currentProc, new object());
                                lock (lockObject)
                                {
                                    Console.WriteLine("Currently Executing " + currentProc + " " + sw.ElapsedTicks);
                                    Console.WriteLine("Ended Executing " + currentProc + " " + sw.ElapsedTicks);
                                }
                                ((IDictionary) locks).Remove(currentProc);
                            }
                        });
                    }
                }
                // Thread.Sleep(0);
            }
        }
        Console.ReadLine();
    }

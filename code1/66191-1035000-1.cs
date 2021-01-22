    class Program
    {
        struct ProcessStartTimePair
        {
            public Process Process { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime ExitTime
            {
                get
                {
                    return DateTime.Now; // approximate value
                }
            }
            public ProcessStartTimePair(Process p) : this()
            {
                Process = p;
                try
                {
                    StartTime = p.StartTime;
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    StartTime = DateTime.Now; // approximate value
                }
            }
        }
        static void Main(string[] args)
        {
            List<ProcessStartTimePair> knownProcesses = new List<ProcessStartTimePair>();
            while (true)
            {
                foreach (Process p in Process.GetProcesses())
                {
                    if (!knownProcesses.Select(x => x.Process.Id).Contains(p.Id))
                    {
                        knownProcesses.Add(new ProcessStartTimePair(p));
                        Console.WriteLine("Detected new process: " + p.ProcessName);
                    }
                }
                for (int i = 0; i < knownProcesses.Count; i++) 
                {
                    ProcessStartTimePair pair = knownProcesses[i];
                    try
                    {
                        if (pair.Process.HasExited)
                        {
                            Console.WriteLine(pair.Process.ProcessName + " has exited (alive from {0} to {1}).", pair.StartTime.ToString(), pair.ExitTime.ToString());
                            knownProcesses.Remove(pair);
                            i--; // List was modified, 1 item less
                            // TODO: Store in the info in the database
                        }
                    }
                    catch (System.ComponentModel.Win32Exception)
                    {
                        // Would have to check whether the process still exists in Process.GetProcesses().
                        // The process probably is a system process.
                    }
                }
                Console.WriteLine();
                System.Threading.Thread.Sleep(1000);
            }
        }
    }

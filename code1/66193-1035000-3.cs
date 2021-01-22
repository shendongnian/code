        static void Main(string[] args)
        {
            List<ProcessStartTimePair> knownProcesses = new List<ProcessStartTimePair>();
            while (true)
            {
                foreach (Process p in Process.GetProcesses())
                {
                    if (!ProcessIsKnown(knownProcesses, p.Id))
                    {
                        knownProcesses.Add(new ProcessStartTimePair(p));
                        Console.WriteLine("Detected new process: " + p.ProcessName);
                    }
                }
                for (int i = 0; i < knownProcesses.Count; i++) 
                [...]
            }
        }
        static bool ProcessIsKnown(List<ProcessStartTimePair> knownProcesses, int ID)
        {
            foreach (ProcessStartTimePair pstp in knownProcesses)
            {
                if (pstp.Process.Id == ID)
                {
                    return true;
                }
            }
            return false;
        }

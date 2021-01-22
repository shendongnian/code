        public List<ProcessData> Processes;
        System.Threading.Thread ProcessThread;
        System.Threading.AutoResetEvent ProcessesChangedEvent = new System.Threading.AutoResetEvent(false);
        void ProcessLoop()
        {
            while (true)
            {
                // You might want to copy out the entire list as an array instead 
                // if HasPriority or Process take a long time.
                lock (Processes)
                {
                    for (int i = 0; i < Processes.Count; i++)
                    {
                        if (HasPriority(Processes[i]))
                        {
                            Process(Processes[i]);
                        }
                    }
                }
                ProcessesChangedEvent.WaitOne(...); // timeout?
            }
        }
        void AddProcessData(ProcessData pd)
        {
            lock (Processes)
                Processes.Add(pd);
            ProcessesChangedEvent.Set(); // you can also use Monitor.PulseAll/Wait
        }
        void Startup()
        {
            ProcessThread = new System.Threading.Thread(ProcessLoop);
            ProcessThread.Start();
        }

        public List<ProcessData> Processes;
        System.Threading.Thread ProcessThread;
        System.Threading.AutoResetEvent ProcessesChangedEvent = new System.Threading.AutoResetEvent(false);
        void ProcessLoop()
        {
            while (true)
            {
                for (int i = 0; i < Processes.Count; i++)
                {
                    if (HasPriority(Processes[i]))
                    {
                        Process(Processes[i]);
                    }
                }
                ProcessesChangedEvent.WaitOne(...); // timeout?
            }
        }
        void AddProcessData(ProcessData pd)
        {
            Processes.Add(pd);
            ProcessesChangedEvent.Set();
        }
        void Startup()
        {
            ProcessThread = new System.Threading.Thread(ProcessLoop);
            ProcessThread.Start();
        }

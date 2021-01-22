        public Queue&lt;ProcessData&gt; Processes;
        System.Threading.Thread[] ProcessThreads = new System.Threading.Thread[5];
        System.Threading.Semaphore semToDo = new System.Threading.Semaphore(0,int.MaxValue);
        void ProcessLoop()
        {
            ProcessData pd; 
            while (true)
            {
                semToDo.WaitOne();
                lock (Processes)
                {
                    pd = Processes.Dequeue();                    
                }
                Process(pd);
            }
        }
        private void Process(ProcessData processData)
        {
            throw new NotImplementedException();
        }
        void AddProcessData(ProcessData pd)
        {
            lock (Processes)
            {
                Processes.Enqueue(pd);
            }
            semToDo.Release();
        }
        void Startup()
        {
            //you can even have multiple worker threads now!
            for(int i = 0; i &lt; 5; i++)
                ProcessThreads[i] = new System.Threading.Thread(ProcessLoop);
            foreach (System.Threading.Thread t in ProcessThreads)
            {
                t.Start();
            }
        }

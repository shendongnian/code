        private int[] _counter = new int[1];
        private int Counter
        {
            get 
            {
                lock (_counter) { return _counter[0]; }
            }
            set 
            {
                lock (_counter) { _counter[0] = value; }
            }
        }
        public void StartMonitor(object state)
        {
            List<Thread> producers = new List<Thread>();
            List<Thread> consumers = new List<Thread>();
            Counter = 0;
            for (int i = 0; i < 1; i++)
            {
                producers.Add(new Thread(() => { Counter++; RunProducers(this.collection); Counter--; }));
            }
            //TODO: Start all producer threads...
            for (int i = 0; i < 2; i++)
            {
                consumers.Add(new Thread(() => { Counter++; RunConsumers(this.collection); Counter--; }));
            }
            //TODO: Let Thread wait until all worker threads are done
            List<Thread> to_check = new List<Thread>(producers);
            to_check.AddRange(consumers);
            while (Counter > 0)
                Thread.Sleep(50);
            //TODO: Dispose Threads
            TimerThread.Change(5000, Timeout.Infinite);
        }

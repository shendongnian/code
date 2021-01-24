    public void StartMonitor(object state)
    {
            List<Thread> producers = new List<Thread>();
            List<Thread> consumers = new List<Thread>();
    
            for (int i = 0; i < 1; i++)
            {
                producers.Add(new Thread(() => RunProducers(this.collection)));
            }
    
            //TODO: Start all producer threads...
    
            for (int i = 0; i < 2; i++)
            {
                consumers.Add(new Thread(() => RunConsumers(this.collection)));
            }
    
           //TODO: Let Thread wait until all worker threads are done
            List<Thread> to_check = new List<Thread>(producers);
            to_check.AddRange(consumers);
            
            while(true)
            {
                Thread.Sleep(50);
                List<Thread> is_alive = new List<Thread>();
                foreach(Thread t in to_check)
                     if(t.IsAlive)
                         is_alive.Add(t);
                if(is_alive.Count == 0)
                    break;
                to_check = is_alive;
            }
            //TODO: Dispose Threads
    
            TimerThread.Change(5000, Timeout.Infinite);
    
    }

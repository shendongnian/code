        public void StartMonitor(object state)
        {
            List<Thread> producers = new List<Thread>();
            List<Thread> consumers = new List<Thread>();
            int producer_cnt = 1,
                consumer_cnt = 2;
            Barrier b = new Barrier(producer_cnt + consumer_cnt + 1);
            try
            {
                for (int i = 0; i < 1; i++)
                {
                    producers.Add(new Thread(() => { try { RunProducers(this.collection); } finally { b.SignalAndWait(); } }));
                }
                //TODO: Start all producer threads...
                for (int i = 0; i < 2; i++)
                {
                    consumers.Add(new Thread(() => { try { RunConsumers(this.collection); } finally { b.SignalAndWait(); } }));
                }
                //TODO: Let Thread wait until all worker threads are done
                List<Thread> to_check = new List<Thread>(producers);
                to_check.AddRange(consumers);
            }
            finally
            {
                b.SignalAndWait();
            }
            //TODO: Dispose Threads
            TimerThread.Change(5000, Timeout.Infinite);
        }

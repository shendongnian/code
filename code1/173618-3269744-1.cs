    public class Example
    {
        private BlockingCollection<string> m_Queue = new BlockingCollection<string>();
    
        public void Start()
        {
            var threads = new Thread[] 
                { 
                    new Thread(Producer), 
                    new Thread(Consumer), 
                    new Thread(Consumer), 
                    new Thread(Consumer) 
                };
            foreach (Thread thread in threads)
            {
                thread.Start();
            }
        }
    
        private void Producer()
        {
            while (true)
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));
                ScheduledTask task = GetScheduledTask();
                if (task != null)
                {
                    foreach (string file in task.Files)
                    {
                        m_Queue.Add(task);
                    }
                }
            }
        }
    
        private void Consumer()
        {
            // Make a connection to the resource that is assigned to this thread only.
            while (true)
            {
                string file = m_Queue.Take();
                // Process the file.
            }
        }
    }

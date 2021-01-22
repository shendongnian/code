    class Worker
    {
        public event EventHandler<EventArgs> Done = (s, e) => { };
    
        public void StartWork()
        {
            var thread = CreateThread();
            thread.Start();
        }
    
        // Seam for extension and testability
        virtual protected Thread CreateThread()
        {
            return new Thread(Work) { Name = "Worker Thread" };
        }
    
        private void Work()
        {
            // Do some heavy lifting
            Thread.Sleep(500);
            Done(this, EventArgs.Empty);
        }
    }
    

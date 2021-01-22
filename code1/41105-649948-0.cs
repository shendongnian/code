        public void OnStart(string[] args) // should this be override?
        {
            var worker = new Thread(DoWork);
            worker.Name = "MyWorker";
            worker.IsBackground = false;
            worker.Start();
        }
        void DoWork()
        {
            // do long-running stuff
        }

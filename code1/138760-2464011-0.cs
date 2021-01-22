    class JobManager
    {
        private object synchObject = new object();
    
        private int _ActiveJobCount;
    
        public int ActiveJobsCount
        {
            get { lock (this.synchObject) { return _ActiveJobCount; } }
            set { lock (this.synchObject) { _ActiveJobCount = value; } }
        }
    
        public void Start(Action job)
        {
            var timer = new System.Timers.Timer(1000);
    
            timer.Elapsed += (sender, e) =>
            {
                this.ActiveJobsCount++;
                job();
                this.ActiveJobsCount--;
            };
    
            timer.Start();
        }
    }
    

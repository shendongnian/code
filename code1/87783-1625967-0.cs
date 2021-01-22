    public class Scraper
    {
        private int MaxUserID { get; set; }
        private int MaxThreads { get; set; }
        private int currentUserID;
        private bool Running { get; set; }
        private Parser StatsParser = new Parser();
        private int Multiplier { get; set; }
        public Scraper()
            : this(0, Int32.MaxValue, 25)
        {
        }
        public Scraper(int currentUserID, int maxUserID, int maxThreads)
        {
            this.currentUserID = currentUserID;
            this.MaxUserID = maxUserID;
            this.MaxThreads = maxThreads;
            this.Running = false;
            ThreadPool.SetMaxThreads(maxThreads, maxThreads);
            Multiplier = 3;
        }
        public void Start()
        {
            Running = true;
            for (int i = 0; i &lt; MaxThreads * Multiplier; i++)
            {
                ThreadPool.QueueUserWorkItem(Process);
            }
        }
        public void Stop()
        {
            Running = false;
        }
        public void Process(object state)
        {
            if (Running == false)
            {
                return;
            }
            if (currentUserID &lt; MaxUserID)
            {
                Interlocked.Increment(ref currentUserID);
                //Parse stats for currentUserID
                ThreadPool.QueueUserWorkItem(Process);
            }
            else
            { Running = false; }
        }
    }

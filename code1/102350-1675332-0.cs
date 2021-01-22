    // WCF class  
    public class RequestManager  
    {
       // WCF method
       public void StartNewJob()
       {
          Job myJob = new Job();
          // Initialise myJob...
          myJob.Start();
       }
    }
    public class Job
    {
        private Timer myTimer = new Timer();
    
        public Job()
        {
            myTimer.Elapsed += new ElapsedEventHandler(this.OnTimedEvent);
        }
        
        public void Start(int Miniutes)
        {
            myTimer.Interval = 60000 * Miniutes;
            myTimer.Enabled = true;
        }
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
         // So something
        }
    }

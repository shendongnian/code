    namespace WorkService
    {
        public partial class WorkService : ServiceBase
        {
    	AutoResetEvent serviceStopEvent = new AutoResetEvent( false);
    
            public WorkService()
            {
                InitializeComponent();
            }
    
            protected override void OnStart(string[] args)
            {
                Thread workerThread = new Thread(new ThreadStart(DoWork));
                workerThread.Start();
            }
    
            protected override void OnStop()
            {
               serviceStopEvent.Set();
            }
    
            static void DoWork()
            {
                int sleepMinutes = 30;
    	    WaitHandle[ ] handles = new WaitHandle[ ] { serviceStopEvent };
    
                while (WaitHandle.WaitAny( handles))
                {
                     ActualWorkDoneHere();
    
                }
            }
    
        }
    }

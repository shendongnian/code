    public class WorkerClass
    {
        public static event ProgressInfoEventHandler ProgressInfo;
        private static void OnProgressInfo(string message)
        {
            if (ProgressInfo != null)
                ProgressInfo(new ProgressInfoEventArgs(message));
        }
        private void DoWork()
        {
              OnProgressInfo("Doing some work");
        }
    
    }

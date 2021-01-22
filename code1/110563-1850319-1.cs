    public class Main
    {
       public Main()
       {
            WorkerClass.ProgressInfo += 
                 new ProgressInfoEventHandler(WorkerClass_ProgressInfo);
       }
        void WorkerClass_ProgressInfo(ProgressInfoEventArgs e)
        {
            //LogMessage(e.Message);
        }
        
    }

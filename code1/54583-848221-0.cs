    public interface IMyWorker
    {
        bool WorkerReportsProgress { get; set; }
        bool WorkerSupportsCancellation { get; set; }
        event DoWorkEventHandler DoWork;
        event ProgressChangedEventHandler ProgressChanged;
        event RunWorkerCompletedEventHandler RunWorkerCompleted;
    }
    public class MyWorker : BackgroundWorker, IMyWorker
    {
        
    }

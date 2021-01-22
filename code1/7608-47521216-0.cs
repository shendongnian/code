    public class DoesStuff
    {
        BackgroundWorker _worker = new BackgroundWorker();
        ...
        public void CancelDoingStuff()
        {
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler((sender, e) => 
            {
                // do whatever you want to do when the cancel completes in here!
            });
            _worker.CancelAsync();
        }
    }

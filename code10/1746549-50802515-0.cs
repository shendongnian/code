    internal class Worker
    {
        ILog log = LogManager.GetLogger(typeof(Worker));
        ...
    
        public async void DoWork() {
             log .Info("This should be logged fine!");
             ...
        }
    }

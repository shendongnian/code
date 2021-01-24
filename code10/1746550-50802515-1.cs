    internal class Worker
    {
        static ILog log = LogManager.GetLogger(typeof(Worker));
        ...
    
        public async void DoWork() {
             log .Info("This should be logged fine!");
             ...
        }
    }

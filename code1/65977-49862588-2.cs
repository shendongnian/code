    public class WorkerPool<T> : IDisposable
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        BlockingCollection<T> queue = new BlockingCollection<T>();
        List<Task> taskList;
        bool isShutdown = false;
        private CancellationTokenSource cancellationToken;
        int maxWorkers;
        private bool wasShutDown;
        public WorkerPool(CancellationTokenSource cancellationToken, int maxWorkers)
        {
            this.cancellationToken = cancellationToken;
            this.maxWorkers = maxWorkers;
            this.taskList = new List<Task>();            
        }
        public void enqueue(T value)
        {
            queue.Add(value);           
        }
        //call to signal that there are no more items
        public void CompleteAdding()
        {
            queue.CompleteAdding();
            log.Debug("CompleteAdding");
        }
        //create workers and put then running
        public void startWorkers(Action<T> worker)
        {            
            log.Debug("Start");
            log.Debug($"prepare {maxWorkers} workers");
            for (int i = 0; i < maxWorkers; i++)
            {
                taskList.Add(new Task(() =>
                {
                    string myname = "worker " + Guid.NewGuid().ToString();
                    log.Debug($"{myname} started");
                    while (!isShutdown)
                    {
                        if (queue.TryTake(out T value))
                        {
                            //just in case you need to abort on demand
                            if (cancellationToken.IsCancellationRequested)
                                throw new ApplicationException("Shutting down on request");
                            worker(value);
                            log.Debug($"processing {value}");
                            countdown.Signal();
                        }
                    }
                    log.Debug($"{myname} Shutdown complete");
                }));
            }
            log.Debug("start workers");
            foreach (var task in taskList)
            {
                task.Start();
            }
        }
        //wait for all work to be finish
        public void await()
        {
            while (queue.Count > 0)
                Thread.Sleep(100);
            shutdown();
        }
        private void shutdown()
        {
            log.Debug("Shutting down");
            isShutdown = true;
            Task.WaitAll(taskList.ToArray());
            log.Debug("Shutdown complete");
            wasShutDown = true;
        }
        //case something bad happen dismiss all pending work
        public void Dispose()
        {
            if (!wasShutDown)
            {
                queue.CompleteAdding();
                shutdown();
            }
        }
    }

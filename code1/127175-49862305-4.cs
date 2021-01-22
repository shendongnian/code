    public class WorkerPool<T> : IDisposable
    {
        BlockingCollection<T> queue = new BlockingCollection<T>();
        List<Task> taskList;
        private CancellationTokenSource cancellationToken;
        int maxWorkers;
        private bool wasShutDown;
        int waitingUnits;
        public WorkerPool(CancellationTokenSource cancellationToken, int maxWorkers)
        {
            this.cancellationToken = cancellationToken;
            this.maxWorkers = maxWorkers;
            this.taskList = new List<Task>();
        }
        public void enqueue(T value)
        {
            queue.Add(value);
            waitingUnits++;
        }
        //call to signal that there are no more item
        public void CompleteAdding()
        {
            queue.CompleteAdding();          
        }
        //create workers and put then running
        public void startWorkers(Action<T> worker)
        {
            for (int i = 0; i < maxWorkers; i++)
            {
                taskList.Add(new Task(() =>
                {
                    string myname = "worker " + Guid.NewGuid().ToString();
                    try
                    {
                        while (!cancellationToken.IsCancellationRequested)
                        {                     
                            var value = queue.Take();
                            waitingUnits--;
                            worker(value);
                        }
                    }
                    catch (Exception ex) when (ex is InvalidOperationException)  //throw when collection is closed with  CompleteAdding method. No pretty way to do this.
                    {
                        //do nothing
                    }
                }));
            }
            foreach (var task in taskList)
            {
                task.Start();
            }
        }
        //wait for all workers to be finish their jobs
        public void await()
        {
            while (waitingUnits >0 || !queue.IsAddingCompleted)
                Thread.Sleep(100);
            shutdown();
        }
        private void shutdown()
        {
            wasShutDown = true;
            Task.WaitAll(taskList.ToArray());            
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

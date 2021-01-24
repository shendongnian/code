    public class TaskWorkerHub
    {
        ConcurrentQueue<Action> workQueue = new ConcurrentQueue<Action>();
        int concurrentTasks;
        CancellationTokenSource cancelSource;
        List<Task> workers = new List<Task>();
    
        private async Task Worker(CancellationToken cancelToken)
        {
            while (workQueue.TryDequeue(out var workTuple))
            {
                await Task.Run(workTuple, cancelToken);
            }
        }
    
        public TaskWorkerHub(int concurrentTasks = 4)
        {
            this.concurrentTasks = concurrentTasks;
        }
    
        public void Enqueue(Action work) => workQueue.Enqueue(work);
    
        public void Start()
        {
            cancelSource  = new CancellationTokenSource();
    
            for (int i = 0; i < concurrentTasks; i++)
            {        
                workers.Add(Worker(cancelSource.Token));
            }
        }
    
        public void Stop() => cancelSource.Cancel();
    
        public Task WaitAsync() => Task.WhenAll(workers);    
    }

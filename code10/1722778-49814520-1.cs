    public BackgroundService : IHostedService
    {
        private readonly TasksToRun _tasks;
        private CancellationTokenSource _tokenSource;
        public BackgroundService(TasksToRun tasks) => _tasks = tasks;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _tokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            while (cancellationToken.IsCancellationRequested == false)
            {
                try
                {
                    var taskToRun = _tasks.Dequeue(cancellationToken);
                    ExecuteTask(taskToRun);
                }
                catch (OperationCanceledException)
                {
                    // execution cancelled
                }
            }
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _tokenSource.Cancel(); // cancel "waiting" for task in blocking collection
        }
    }

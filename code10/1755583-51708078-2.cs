    public class CancellableTask
        {
            private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            private Task cancellationTask = null;
            private Action<Task> method;
            private int delayMilis;
    
            public bool Delayed { get; private set; }
    
            public TaskStatus TaskStatus => cancellationTask.Status;
    
            public CancellableTask(Action<Task> task)
            {
                method = task;
            }
    
            public bool Cancel()
            {
                if (cancellationTask != null && (cancellationTask.Status == TaskStatus.Running || cancellationTask.Status == TaskStatus.WaitingForActivation))
                {
                    cancellationTokenSource.Cancel();
                    cancellationTokenSource.Dispose();
                    cancellationTokenSource = new CancellationTokenSource();
                    return true;
                }
                return false;
            }
    
            public void Run()
            {
                Delayed = false;
                StartTask();
            }
    
            public void Run(int delayMiliseconds)
            {
                if(delayMiliseconds < 0)
                    throw new ArgumentOutOfRangeException();
    
                Delayed = true;
                delayMilis = delayMiliseconds;
                StartDelayedTask();
            }
    
            private void DelayedTask(int delay)
            {
                CancellationToken cancellationToken = cancellationTokenSource.Token;
                try
                {
                    cancellationTask =
                        Task.
                            Delay(TimeSpan.FromMilliseconds(delay), cancellationToken).
                            ContinueWith(method, cancellationToken);
    
                    while (true)
                    {
                        if (cancellationTask.IsCompleted)
                            break;
    
                        if (cancellationToken.IsCancellationRequested)
                        {
                            cancellationToken.ThrowIfCancellationRequested();
                            break;
                        }
                    }
                }
                catch (Exception e)
                {
                    //handle exception
                    return;
                }
    
            }
    
            private void NormalTask()
            {
                CancellationToken cancellationToken = cancellationTokenSource.Token;
                try
                {
                    cancellationTask =
                        Task.Run(() => method, cancellationToken);
    
                    while (true)
                    {
                        if (cancellationTask.IsCompleted)
                            break;
    
                        if (cancellationToken.IsCancellationRequested)
                        {
                            cancellationToken.ThrowIfCancellationRequested();
                            break;
                        }
                    }
                }
                catch (Exception e)
                {
                    //handle exception
                    return;
                }
            }
    
            private void StartTask()
            {
                Task.Run(() => NormalTask());
            }
    
            private void StartDelayedTask()
            {
                Task.Run(() => DelayedTask(delayMilis));
            }
    
        }

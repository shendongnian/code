    class Program
    {
        static async Task Main(string[] args)
        {
            Action act = null;
            act += () => { Console.WriteLine("Sync"); };
            act += async () =>
            {
                Callback();
    
                await Task.Delay(1000);
    
                Console.WriteLine("Async");
            };
    
            await AwaitAction(act);
    
            Console.WriteLine("Done");
    
            Console.ReadLine();
        }
    
        static async void Callback()
        {
            await Task.Delay(2000);
    
            Console.WriteLine("Async2");
        }
    
        static Task AwaitAction(Action action)
        {
            var delegates = action.GetInvocationList();
    
            var oldSynchronizationContext = SynchronizationContext.Current;
    
            var asyncVoidSynchronizationContext = new AsyncVoidSynchronizationContext();
    
            try
            {
                SynchronizationContext.SetSynchronizationContext(asyncVoidSynchronizationContext);
    
                var tasks = new Task[delegates.Length];
    
                for (int i = 0; i < delegates.Length; i++)
                {
                    ((Action)delegates[i]).Invoke();
                    tasks[i] = asyncVoidSynchronizationContext.GetTaskForLastOperation();
                }
    
                return Task.WhenAll(tasks);
            }
            finally
            {
                SynchronizationContext.SetSynchronizationContext(oldSynchronizationContext);
            }
        }
    }
    
    public class AsyncVoidSynchronizationContext : SynchronizationContext
    {
        private TaskCompletionSource<object> _tcs;
        private Task _latestTask;
    
        private int _operationCount;
    
        public Task GetTaskForLastOperation()
        {
            if (_latestTask != null)
            {
                var task = _latestTask;
                _latestTask = null;
                return task;
            }
    
            return Task.CompletedTask;
        }
    
        public override void Post(SendOrPostCallback d, object state)
        {
            Task.Run(() =>
            {
                SynchronizationContext.SetSynchronizationContext(this);
    
                d(state);
            });
        }
    
        public override SynchronizationContext CreateCopy()
        {
            return this;
        }
    
        public override void OperationStarted()
        {
            if (Interlocked.Increment(ref _operationCount) == 1)
            {
                _tcs = new TaskCompletionSource<object>();
                _latestTask = _tcs.Task;
            }
    
            base.OperationStarted();
        }
    
        public override void OperationCompleted()
        {
            if (Interlocked.Decrement(ref _operationCount) == 0)
            {
                _tcs.TrySetResult(null);
            }
    
            base.OperationCompleted();
        }
    }

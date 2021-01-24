    public class MyAwaiter : INotifyCompletion
    {
        private readonly MyAwaitable awaitable;
        private readonly bool captureContext;
        public MyAwaiter(MyAwaitable awaitable, bool captureContext)
        {
            this.awaitable = awaitable;
            this.captureContext = captureContext;
        }
        public MyAwaiter GetAwaiter() => this;
        public bool IsCompleted => awaitable.IsCompleted;
        public int GetResult() => awaitable.RunToCompletionAndGetResult();
        public void OnCompleted(Action continuation)
        {
            var capturedContext = SynchronizationContext.Current;
            awaitable.ScheduleContinuation(() =>
            {
                if (captureContext && capturedContext != null)
                    capturedContext.Post(_ => continuation(), null);
                else
                    continuation();
            });
        }
    }

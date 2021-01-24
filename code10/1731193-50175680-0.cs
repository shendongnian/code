    class DispatcherSynchronizeInvoke : ISynchronizeInvoke
    {
        private readonly Dispatcher dispatcher;
        public DispatcherSynchronizeInvoke(Dispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }
        public IAsyncResult BeginInvoke(Delegate method, object[] args)
        {
            // Obtaining a DispatcherOperation instance
            // and wrapping it with our proxy class
            return new DispatcherAsyncResult(
                this.dispatcher.BeginInvoke(method, DispatcherPriority.Normal, args));
        }
        public object EndInvoke(IAsyncResult result)
        {
            DispatcherAsyncResult dispatcherResult = result as DispatcherAsyncResult;
            dispatcherResult.Operation.Wait();
            return dispatcherResult.Operation.Result;
        }
        public object Invoke(Delegate method, object[] args)
        {
            return dispatcher.Invoke(method, DispatcherPriority.Normal, args);
        }
        public bool InvokeRequired => !this.dispatcher.CheckAccess();
        // We also could use the DispatcherOperation.Task directly
        private class DispatcherAsyncResult : IAsyncResult
        {      
            private readonly IAsyncResult result;
            public DispatcherAsyncResult(DispatcherOperation operation)
            {
                this.Operation = operation;
                this.result = operation.Task;
            }
            public DispatcherOperation Operation { get; }
            public bool IsCompleted => this.result.IsCompleted;
            public WaitHandle AsyncWaitHandle => this.result.AsyncWaitHandle;
            public object AsyncState => this.result.AsyncState;
            public bool CompletedSynchronously => this.result.CompletedSynchronously;
        }
    }

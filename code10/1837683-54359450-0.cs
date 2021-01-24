    internal class CompletedAsyncResult : IAsyncResult
    {
        public CompletedAsyncResult(object state)
        {
            this.AsyncState = state;
        }
        public object AsyncState { get; set; }
        public WaitHandle AsyncWaitHandle => new ManualResetEvent(true);
        public bool CompletedSynchronously => true;
        public bool IsCompleted => true;
    }

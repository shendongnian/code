    public class MyAwaitable
    {
        private volatile bool completed;
        private volatile int result;
        private Action continuation;
        public bool IsCompleted => completed;
        public int Result => RunToCompletionAndGetResult();
        public MyAwaitable(int? result = null)
        {
            if (result.HasValue)
            {
                completed = true;
                this.result = result.Value;
            }
        }
        public void Finish(int result)
        {
            if (completed)
                return;
            completed = true;
            this.result = result;
            continuation?.Invoke();
        }
        public MyAwaiter GetAwaiter() => ConfigureAwait(true);
        public MyAwaiter ConfigureAwait(bool captureContext)
            => new MyAwaiter(this, captureContext);
        internal void ScheduleContinuation(Action action) => continuation += action;
        internal int RunToCompletionAndGetResult()
        {
            var wait = new SpinWait();
            while (!completed)
                wait.SpinOnce();
            return result;
        }
    }

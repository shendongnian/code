    public static class Tasks
    {
        public static Task<TResult> FromResult<TResult>(TResult result)
        {
            var tcs = new TaskCompletionSource<TResult>();
            tcs.SetResult(result);
            return tcs.Task;
        }
        public static Task WhenAll(Task[] tasks)
        {
            return Task.Factory.ContinueWhenAll(tasks, (t) => t);
        }
        public static Task Delay(int millisecondsDelay)
        {
            var tcs = new TaskCompletionSource<object>();
            new Timer(_ => tcs.SetResult(null)).Change(millisecondsDelay, -1);
            return tcs.Task;
        }
    }

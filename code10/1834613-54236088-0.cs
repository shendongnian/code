    public class LimitedTimeAwaiter<T>
    {
        public static async Task<T> Execute(Func<CancellationToken, Task<T>> function, CancellationToken originalToken, int awaitTime)
        {
            originalToken.ThrowIfCancellationRequested();
            var timeout = CancellationTokenSource.CreateLinkedTokenSource(originalToken);
            timeout.CancelAfter(TimeSpan.FromSeconds(awaitTime));
            try
            {
                return await function(timeout.Token);
            }
            catch (OperationCanceledException err)
            {
                throw new Exception("LimitedTimeAwaiter ended function ahead of time", err);
            }
        }
    }

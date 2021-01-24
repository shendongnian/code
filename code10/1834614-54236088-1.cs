    public class LimitedTimeAwaiter<T>
    {
        public static async Task<T> Execute(Func<CancellationToken, Task<T>> function, CancellationToken originalToken, int awaitTime)
        {
            originalToken.ThrowIfCancellationRequested();
            var timeout = CancellationTokenSource.CreateLinkedTokenSource(originalToken);
            timeout.CancelAfter(TimeSpan.FromSeconds(awaitTime));
            try
            {
                var httpClientTask = function(timeout.Token);
                var timeoutTask = Task.Delay(Timeout.Infinite, timeout.Token); // This is a trick to link a task to a CancellationToken
                var task = await Task.WhenAny(httpClientTask, timeoutTask);
                // At this point, one of the task completed
                // First, check if we timed out
                timeout.Token.ThrowIfCancellationRequested();
                // If we're still there, it means that the call to HttpClient completed
                timeout.Cancel(); // Clean the associated timer
                return await httpClientTask;
            }
            catch (OperationCanceledException err)
            {
                throw new Exception("LimitedTimeAwaiter ended function ahead of time", err);
            }
        }
    }

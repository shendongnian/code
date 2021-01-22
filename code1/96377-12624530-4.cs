    public static class ThreadUtils
    {
        public static RetryResult Retry(
            Action target,
            CancellationToken cancellationToken,
            int timeout = 5000,
            int retries = 0)
        {
            CheckRetryParameters(timeout, retries)
            var failures = new List<Exception>();
            while(!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    target();
                    return new RetryResult(failures);
                }
                catch (Exception ex)
                {
                    failures.Add(ex);
                }
                if (retries > 0)
                {
                    retries--;
                    if (retries == 0)
                    {
                        throw new AggregateException(
                         "Retry limit reached, see InnerExceptions for details.",
                         failures);
                    }
                }
                if (cancellationToken.WaitHandle.WaitOne(timeout))
                {
                    break;
                }
            }
            failures.Add(new OperationCancelledException(
                "The Retry Operation was cancelled."));
            throw new AggregateException("Retry was cancelled.", failures);
        }
        private static void CheckRetryParameters(int timeout, int retries)
        {
            if (timeout < 1)
            {
                throw new ArgumentOutOfRangeException(...
            }
            if (retries < 0)
            {
                throw new ArgumentOutOfRangeException(...
            }
        }
        public class RetryResult : IEnumerable<Exception>
        {
            private readonly IEnumerable<Exception> failureExceptions;
            private readonly int failureCount;
             protected internal RetryResult(
                 ICollection<Exception> failureExceptions)
             {
                 this.failureExceptions = failureExceptions;
                 this.failureCount = failureExceptions.Count;
             }
        }
        public int FailureCount
        {
            get { return this.failureCount; }
        }
        public IEnumerator<Exception> GetEnumerator()
        {
            return this.failureExceptions.GetEnumerator();
        }
        System.Collections.IEnumerator 
            System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    const string RetryCountKey = "RetryCount";
    RetryPolicy retryStoringRetryCount = Policy
        .Handle<Exception>()
        .Retry(3, (exception, retryCount, context) =>
        {
            Console.WriteLine("Storing retry count of " + retryCount + " in execution context.");
            context[RetryCountKey] = retryCount;
        });
    TimeoutPolicy timeoutBasedOnRetryCount = Policy
        .Timeout(context =>
        {
            int tryCount;
            try
            {
                tryCount = (int) context[RetryCountKey];
            }
            catch
            {
                tryCount = 0; // choose your own default for when it is not set; also applies to first try, before any retries
            }
            int timeoutMs = 25 * (tryCount + 1);
            Console.WriteLine("Obtained retry count of " + tryCount + " from context, thus timeout is " + timeoutMs + " ms.");
            return TimeSpan.FromMilliseconds(timeoutMs);
        });
    PolicyWrap policiesTogether = retryStoringRetryCount.Wrap(timeoutBasedOnRetryCount);

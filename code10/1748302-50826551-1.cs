    class HttpRetryWrapper
    {
        private static policy = Policy.Handle<HttpRequestException>()
            .Or<TimeoutException>()
            .WaitAndRetryAsync(
                3,
                retryAttempt => TimeSpan.FromSeconds(Math.Pow(5, retryAttempt)),
                (exception, timeSpan, retryCount, context) =>
                {
                    //do some logging
                });
        public static Task ExecuteAsync(Func<Task> func) 
        {
            return policy.ExecuteAsync(func);
        }
        public static Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> func) 
        {
            return policy.ExecuteAsync<TResult>(func);
        }
    }

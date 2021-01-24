    public static Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> func) 
    {
        return Policy.Handle<HttpRequestException>()
            .Or<TimeoutException>()
            .WaitAndRetryAsync(
                3,
                retryAttempt => TimeSpan.FromSeconds(Math.Pow(5, retryAttempt)),
                (exception, timeSpan, retryCount, context) =>
                {
                    //do some logging
                })
            .ExecuteAsync<TResult>(func); // This is an async-await-eliding contraction of: .ExecuteAsync<TResult>(async () => await func());
        }

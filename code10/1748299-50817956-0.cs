    public static T Execute<T>(Func<T> func) where T : Task
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
            .ExecuteAsync(func).Wait();
    }

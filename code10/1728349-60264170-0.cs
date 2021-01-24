        public static class Policies
        {
            public const int HttpThrottleErrorCode = 429;
            public const int HttpServiceIsUnavailable = 1;
            public const int HttpOperationExceededTimeLimit = 50;
            public const int RateLimitCode = 16500;
            public const string RetryAfterToken = "RetryAfterMs=";
            public const int MaxRetries = 10;
            public static readonly int RetryAfterTokenLength = RetryAfterToken.Length;
            private static readonly Random JitterSeed = new Random();
            public static readonly IAsyncPolicy NoPolicy = Policy.NoOpAsync();
            public static Func<int, TimeSpan> SleepDurationProviderWithJitter(double exponentialBackoffInSeconds, int maxBackoffTimeInSeconds) => retryAttempt
                => TimeSpan.FromSeconds(Math.Min(Math.Pow(exponentialBackoffInSeconds, retryAttempt), maxBackoffTimeInSeconds)) // exponential back-off: 2, 4, 8 etc
                   + TimeSpan.FromMilliseconds(JitterSeed.Next(0, 1000)); // plus some jitter: up to 1 second
            public static readonly Func<int, TimeSpan> DefaultSleepDurationProviderWithJitter =
                SleepDurationProviderWithJitter(1.5, 23);
            public static readonly IAsyncPolicy MongoCommandExceptionPolicy = Policy
                .Handle<MongoCommandException>(e =>
                {
                    if (e.Code != RateLimitCode || !(e.Result is BsonDocument bsonDocument))
                    {
                        return false;
                    }
                    if (bsonDocument.TryGetValue("StatusCode", out var statusCode) && statusCode.IsInt32)
                    {
                        switch (statusCode.AsInt32)
                        {
                            case HttpThrottleErrorCode:
                            case HttpServiceIsUnavailable:
                            case HttpOperationExceededTimeLimit:
                                return true;
                            default:
                                return false;
                        }
                    }
                    if (bsonDocument.TryGetValue("IsValid", out var isValid) && isValid.IsBoolean)
                    {
                        return isValid.AsBoolean;
                    }
                    return true;
                })
                .WaitAndRetryAsync(
                    retryCount: MaxRetries,
                    DefaultSleepDurationProviderWithJitter
                );
            public static readonly IAsyncPolicy ExecutionTimeoutPolicy = Policy
                .Handle<MongoExecutionTimeoutException>(e =>
                    e.Code == RateLimitCode || e.Code == HttpOperationExceededTimeLimit
                )
                .WaitAndRetryAsync(
                    retryCount: MaxRetries,
                    DefaultSleepDurationProviderWithJitter
                );
            public static readonly IAsyncPolicy MongoWriteExceptionPolicy = Policy
                .Handle<MongoWriteException>(e =>
                {
                    return e.WriteError?.Code == RateLimitCode
                           || (e.InnerException is MongoBulkWriteException bulkException &&
                               bulkException.WriteErrors.Any(error => error.Code == RateLimitCode));
                })
                .WaitAndRetryAsync(
                    retryCount: MaxRetries,
                    sleepDurationProvider: (retryAttempt, e, ctx) =>
                    {
                        var timeToWaitInMs = ExtractTimeToWait(e.Message);
                        if (!timeToWaitInMs.HasValue && e.InnerException != null)
                        {
                            timeToWaitInMs = ExtractTimeToWait(e.InnerException.Message);
                        }
                        return timeToWaitInMs ?? DefaultSleepDurationProviderWithJitter(retryAttempt);
                    },
                    onRetryAsync: (e, ts, i, ctx) => Task.CompletedTask
                );
            public static readonly IAsyncPolicy MongoBulkWriteExceptionPolicy = Policy
                .Handle<MongoBulkWriteException>(e =>
                {
                    return e.WriteErrors.Any(error => error.Code == RateLimitCode);
                })
                .WaitAndRetryAsync(
                    retryCount: MaxRetries,
                    sleepDurationProvider: (retryAttempt, e, ctx) =>
                    {
                        var timeToWaitInMs = ExtractTimeToWait(e.Message);
                        return timeToWaitInMs ?? DefaultSleepDurationProviderWithJitter(retryAttempt);
                    },
                    onRetryAsync: (e, ts, i, ctx) => Task.CompletedTask
                );
            /// <summary>
            /// It doesn't seem like RetryAfterMs is a property value - so unfortunately, we have to extract it from a string... (crazy??!)
            /// </summary>
            private static TimeSpan? ExtractTimeToWait(string messageToParse)
            {
                var retryPos = messageToParse.IndexOf(RetryAfterToken, StringComparison.OrdinalIgnoreCase);
                if (retryPos >= 0)
                {
                    retryPos += RetryAfterTokenLength;
                    var endPos = messageToParse.IndexOf(',', retryPos);
                    if (endPos > 0)
                    {
                        var timeToWaitInMsString = messageToParse.Substring(retryPos, endPos - retryPos);
                        if (Int32.TryParse(timeToWaitInMsString, out int timeToWaitInMs))
                        {
                            return TimeSpan.FromMilliseconds(timeToWaitInMs)
                                   + TimeSpan.FromMilliseconds(JitterSeed.Next(100, 1000));
                        }
                    }
                }
                return default;
            }
            /// <summary>
            /// Use this policy if your CosmosDB MongoDB endpoint is V3.2
            /// </summary>
            public static readonly IAsyncPolicy DefaultPolicyForMongo3_2 = Policy.WrapAsync(MongoCommandExceptionPolicy, ExecutionTimeoutPolicy);
            /// <summary>
            /// Use this policy if your CosmosDB MongoDB endpoint is V3.6 or V3.2
            /// </summary>
            public static readonly IAsyncPolicy DefaultPolicyForMongo3_6 = Policy.WrapAsync(MongoCommandExceptionPolicy, ExecutionTimeoutPolicy, MongoWriteExceptionPolicy, MongoBulkWriteExceptionPolicy);
        }
        public static IAsyncPolicy DefaultPolicy { get; set; } = Policies.DefaultPolicyForMongo3_6;

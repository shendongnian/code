    public static async Task Run(DurableOrchestrationContext context)
    {
        var retryOptions = new RetryOptions(
            firstRetryInterval: TimeSpan.FromSeconds(5),
            maxNumberOfAttempts: 3);
    
        await ctx.CallActivityWithRetryAsync("FlakyFunction", retryOptions, null);
    
        // ...
    }

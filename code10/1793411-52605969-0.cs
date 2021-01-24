    if (host.PollyRetryWaitPolicy == null)
    {
        // NOTE: Only add this timeout policy as it seems to need at least one
        // policy before it can wrap! (suppose that makes sense).
        var timeoutPolicy = Policy
            .TimeoutAsync(TimeSpan.FromSeconds(waitTimeInSeconds), TimeoutStrategy.Pessimistic);
        PollyRetryWaitPolicy = policy.WrapAsync(timeoutPolicy);
    }
    else
    {
        PollyRetryWaitPolicy.WrapAsync(policy);
    }

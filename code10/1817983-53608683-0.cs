    services.AddHttpClient<MyServiceHttpClient>(/* etc */)
        .AddPolicyHandler((services, request) => HttpPolicyExtensions.HandleTransientHttpError()
            .WaitAndRetryAsync(new[]
            {
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(5),
                TimeSpan.FromSeconds(10)
            },             
            onRetry: (outcome, timespan, retryAttempt, context) =>
            {
                services.GetService<ILogger<MyServiceHttpClient>>()
                    .LogWarning("Delaying for {delay}ms, then making retry {retry}.", timespan.TotalMilliseconds, retryAttempt);
            }
            ));

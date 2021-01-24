      public static IServiceCollection AddPollyPolicies(this IServiceCollection services, Action<PollyPoliciesOptions> setupAction = null)
        {
            var policyOptions = new PollyPoliciesOptions();
            setupAction?.Invoke(policyOptions);
            var policyRegistry = services.AddPolicyRegistry();
            policyRegistry.Add(
                PollyPolicyName.HttpRetry,
                HttpPolicyExtensions
                    .HandleTransientHttpError()
                    .WaitAndRetryAsync(
                        policyOptions.HttpRetry.Count,
                        retryAttempt => TimeSpan.FromSeconds(Math.Pow(policyOptions.HttpRetry.BackoffPower, retryAttempt))));
            policyRegistry.Add(
                PollyPolicyName.HttpCircuitBreaker,
                HttpPolicyExtensions
                    .HandleTransientHttpError()
                    .CircuitBreakerAsync(
                        handledEventsAllowedBeforeBreaking: policyOptions.HttpCircuitBreaker.ExceptionsAllowedBeforeBreaking,
                        durationOfBreak: policyOptions.HttpCircuitBreaker.DurationOfBreak));
            return services;
        }

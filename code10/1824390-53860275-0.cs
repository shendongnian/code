    using Polly;
    using Polly.CircuitBreaker;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
					
    public class Program
    {
        public static void Main()
        {
            int maxRetryCount = 6;
            double circuitBreakDurationSeconds = 0.2 /* experiment with effect of shorter or longer here, eg: change to = 1, and the fallbackForCircuitBreaker is correctly invoked */ ;
            int maxExceptionsBeforeBreaking = 4; /* experiment with effect of fewer here, eg change to = 1, and the fallbackForCircuitBreaker is correctly invoked */
            int maxParallelizations = 2;
            int maxQueuingActions = 2;
            var retryPolicy = Policy.Handle<Exception>(e => (e is HttpRequestException || (/*!(e is BrokenCircuitException) &&*/ e.InnerException is HttpRequestException))) // experiment with introducing the extra (!(e is BrokenCircuitException) && ) clause here, if necessary
                .WaitAndRetry(
                    retryCount: maxRetryCount,
                    sleepDurationProvider: attempt => TimeSpan.FromMilliseconds(50 * Math.Pow(2, attempt)),
                    onRetry: (ex, calculatedWaitDuration, retryCount, context) =>
                    {
                        Console.WriteLine(String.Format("Retry => Count: {0}, Wait duration: {1}, Policy Wrap: {2}, Policy: {3}, Endpoint: {4}, Exception: {5}", retryCount, calculatedWaitDuration, context.PolicyWrapKey, context.PolicyKey, context.OperationKey, ex.Message));
                    });
            var circuitBreaker = Policy.Handle<Exception>(e => (e is HttpRequestException || e.InnerException is HttpRequestException))
                .CircuitBreaker(maxExceptionsBeforeBreaking,
                    TimeSpan.FromSeconds(circuitBreakDurationSeconds),
                    onBreak: (ex, breakDuration) => {
                        Console.WriteLine(String.Format("Circuit breaking for {0} ms due to {1}", breakDuration.TotalMilliseconds, ex.Message));
                    },
                    onReset: () => {
                        Console.WriteLine("Circuit closed again.");
                    },
                    onHalfOpen: () => { Console.WriteLine("Half open."); });
            var sharedBulkhead = Policy.Bulkhead(maxParallelizations, maxQueuingActions);
            var fallbackForCircuitBreaker = Policy<bool>
                 .Handle<BrokenCircuitException>()
                /* .OrInner<BrokenCircuitException>() */ // Consider this if necessary.
                /* .Or<Exception>(e => circuitBreaker.State != CircuitState.Closed) */ // This check will also detect the circuit in anything but healthy state, regardless of the final exception thrown.
                 .Fallback(
                     fallbackValue: false,
                     onFallback: (b, context) =>
                     {
                         Console.WriteLine(String.Format("Operation attempted on broken circuit => Policy Wrap: {0}, Policy: {1}, Endpoint: {2}", context.PolicyWrapKey, context.PolicyKey, context.OperationKey));
                     }
                 );
            var fallbackForAnyException = Policy<bool>
                    .Handle<Exception>()
                    .Fallback<bool>(
                        fallbackAction: (context) => { return false; },
                        onFallback: (e, context) =>
                        {
                            Console.WriteLine(String.Format("An unexpected error occured => Policy Wrap: {0}, Policy: {1}, Endpoint: {2}, Exception: {3}", context.PolicyWrapKey, context.PolicyKey, context.OperationKey, e.Exception.Message));
                        }
                    );
            var resilienceStrategy = Policy.Wrap(retryPolicy, circuitBreaker, sharedBulkhead);
            var policyWrap = fallbackForAnyException.Wrap(fallbackForCircuitBreaker.Wrap(resilienceStrategy));
            bool outcome = policyWrap.Execute((context) => CallApi("http://www.doesnotexistattimeofwriting.com/"), new Context("some endpoint info"));
        }
        public static bool CallApi(string uri)
        {
            using (var httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(1) }) // Consider HttpClient lifetimes and disposal; this pattern is for minimum change from original posted code, not a recommendation.
            {
                Task<HttpResponseMessage> res = httpClient.GetAsync(uri);
                var response = res.Result; // Consider async/await rather than blocking on the returned Task.
                response.EnsureSuccessStatusCode();
                return true;
            }
        }
    }

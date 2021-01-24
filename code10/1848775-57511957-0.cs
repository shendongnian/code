    public class HealthCheckCacher : IHealthCheck
    {
        private readonly SemaphoreSlim _mutex = new SemaphoreSlim(1);
        private readonly IHealthCheck _healthCheck;
        private readonly TimeSpan _timeToLive;
        private HealthCheckResult _result;
        private DateTime _lastCheck;
        public static readonly TimeSpan DefaultTimeToLive = TimeSpan.FromSeconds(30);
        /// <summary>
        /// Creates a new HealthCheckCacher which will cache the result for the amount of time specified.
        /// </summary>
        /// <param name="healthCheck">The underlying health check to perform.</param>
        /// <param name="timeToLive">The amount of time for which the health check should be cached. Defaults to 30 seconds.</param>
        public HealthCheckCacher(IHealthCheck healthCheck, TimeSpan? timeToLive = null)
        {
            _healthCheck = healthCheck;
            _timeToLive = timeToLive ?? DefaultTimeToLive;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            // you could improve thread concurrency by separating the read/write logic but this would require additional thread safety checks.
            // will throw OperationCanceledException if the token is canceled while we're waiting.
            await _mutex.WaitAsync(cancellationToken);
            try
            {
                // previous check is cached & not yet expired; just return it
                if (_lastCheck > DateTime.MinValue && DateTime.Now - _lastCheck < _timeToLive)
                    return _result;
                // check has not been performed or is expired; run it now & cache the result
                _result = await _healthCheck.CheckHealthAsync(context, cancellationToken);
                _lastCheck = DateTime.Now;
                return _result;
            }
            finally
            {
                _mutex.Release();
            }
        }
    }

    public class SomeDependency 
    {
        public string GetMessage() => "Hello from SomeDependency";
    }
    public class CustomHealthCheck : IHealthCheck
    {
        private readonly SomeDependency someDependency;
        public string Name => "MyCustomHealthCheck";
        public CustomHealthCheck(SomeDependency someDependency)
        {
            this.someDependency = someDependency;
        }
        public Task<HealthCheckResult> CheckHealthAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var message = this.someDependency.GetMessage();
            return Task.FromResult(new HealthCheckResult(
                HealthCheckStatus.Healthy, 
                null, 
                null, 
                null) );
        }
    }

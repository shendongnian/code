    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Diagnostics.HealthChecks;
    
    public class SomeDependency
    {
        public string GetMessage() => "Hello from SomeDependency";
    }
    
    public class SomeHealthCheck : IHealthCheck
    {
        public string Name => nameof(SomeHealthCheck);
    
        private readonly SomeDependency someDependency;
    
        public SomeHealthCheck(SomeDependency someDependency)
        {
            this.someDependency = someDependency;
        }
    
        public Task<HealthCheckResult> CheckHealthAsync(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var message = this.someDependency.GetMessage();
            var result = new HealthCheckResult(HealthCheckStatus.Failed, null, null, null);
            return Task.FromResult(result);
        }
    }
    
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();
            services.AddSingleton<SomeDependency>();
            services.AddSingleton<IHealthCheck, SomeHealthCheck>();
        }
    
        public void Configure(IApplicationBuilder app)
        {
            app.UseHealthChecks("/healthz");
            app.Run(async (context) => await context.Response.WriteAsync("Hello World!"));
        }
    }

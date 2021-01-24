public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Here I register my services / repositories; omitted for brevity
        services.AddGraphQL(sp => Schema.Create(c =>
        {
            // Here I register my schema types and so on; omitted for brevity
        }));
    }
     // Code omitted for brevity
}
To enable tracing on demand, you need to set the `TracingPreference` option to `TracingPreference.OnDemand`. The previous code fragment would then look like this.
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Here I register my services / repositories; omitted for brevity
        services.AddGraphQL(sp => Schema.Create(c =>
        {
            // Here I register my schema types and so on; omitted for brevity
        }),
        new QueryExecutionOptions
        {
            TracingPreference = TracingPreference.OnDemand
        });
    }
     // Code omitted for brevity
}
After you have set the tracing preference to `OnDemand`, you just need to pass the following HTTP header `GraphQL-Tracing=1` with every query request you’re interested in. That's all.

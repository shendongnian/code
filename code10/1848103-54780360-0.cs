csharp
public class RequestScopedTelemetry 
{
    public string MyCustomProperty { get; set; }
}
csharp
services.AddScoped<RequestScopedTelemetry>();
Now, create the `ITelemetryInitializer` and register it as a singleton. App Insights will discover and use it through the DI framework.
csharp
class RequestScopedTelemetryInitializer : ITelemetryInitializer
{
    readonly IHttpContextAccessor httpContextAccessor;
    public RequestScopedTelemetryInitializer(IHttpContextAccessor httpContextAccessor)
        => this.httpContextAccessor = httpContextAccessor;
    public void Initialize(ITelemetry telemetry)
    {
        // Attempt to resolve the request-scoped telemetry from the DI container
        var requestScopedTelemetry = httpContextAccessor
            .HttpContext?
            .RequestServices?
            .GetService<RequestScopedTelemetry>();
        // RequestScopedTelemetry is only available within an active request scope
        // If no telemetry available, just move along...
        if (requestScopedTelemetry == null)
            return;
        // If telemetry was available, add it to the App Insights telemetry collection
        telemetry.Context.GlobalProperties[nameof(RequestScopedTelemetry.MyCustomProperty)]
            = requestScopedTelemetry.MyCustomProperty;
    }
}
csharp
services.AddSingleton<ITelemetryInitializer, RequestScopedTelemetryInitializer>();
Finally, in your controller method, set your per-request values. This part isn't necessary if your telemetry class is able to fetch or generate the data itself.
csharp
public class ExampleController : ControllerBase
{
    readonly RequestScopedTelemetry telemetry;
    public ValuesController(RequestScopedTelemetry telemetry)
        => this.telemetry = telemetry;
    [HttpGet]
    public ActionResult Get()
    {
        telemetry.MyCustomProperty = "MyCustomValue";
        // Do what you want to
        return Ok();
    }
}

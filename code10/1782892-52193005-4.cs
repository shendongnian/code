    // Startup.cs
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpClient<SomeService>();
        // ...
    }
    // SomeService.cs
    public class SomeService
    {
        public SomeService(HttpClient httpClient)
        {
            // ...
        }
    }
    // SomeViewComponent.cs
    public class SomeViewComponent
    {
        public SomeViewComponent(SomeService someService)
        {
            // ...
        }
    }

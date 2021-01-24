    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpClient<SomeViewComponent>();
        // ...
    }
    public class SomeViewComponent
    {
        public SomeViewComponent(HttpClient httpClient)
        {
            // ...
        }
    }

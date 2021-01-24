    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpClient<SomeViewComponent>();
        // ...
    }
    public class SomeViewComponent
    {
        public SomeViewComponent(IHttpClientFactory httpClientFactory)
        {
            var httpClient = httpClientFactory.CreateClient("SomeViewComponent")
            // ...
        }
    }

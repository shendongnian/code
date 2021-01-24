    public class Config
    {
        public string SomeConfig { get; set; }
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton(new Config());
    }
    public ProviderA(SMSService smsService, Config configuration)
    {
    }

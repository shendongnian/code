    public class StoreManagerStartup : INopStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new ViewLocationExpander());
            });
        }
        public void Configure(IApplicationBuilder application)
        {
        }
        public int Order {
            get { return 0; } //Return 0 to force this to execute first, otherwise set higher i.e. 1001 
        }
    }

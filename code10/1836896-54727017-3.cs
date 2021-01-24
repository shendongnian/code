    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc(options => options.UseToUppercaseJsonInputFormatter());
        }
    }

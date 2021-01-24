    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services
                .AddAuthentication()
                .AddCookie("Cookie1", option1 =>
                {
                    // config cookie1
                })
                .AddCookie("Cookie2", option2 =>
                {
                    // config cookie2
                });
        }
    }
    [Authorize(AuthenticationSchemes = "Cookie1")]
    public class FooController
    {
    }
    [Authorize(AuthenticationSchemes = "Cookie2")]
    public class BarController
    {
    }

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddAuthentication()
                .AddCookie("CookieA", optionA =>
                {
                    // config cookieA
                })
                .AddCookie("CookieB", optionB =>
                {
                    // config cookieB
                });
        }
    }

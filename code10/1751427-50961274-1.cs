    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCloudServiceGateway();
    
            var config = new HttpConfiguration
            {
                IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always // Add this line to enable detail mode in release
            };
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }

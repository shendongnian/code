    [assembly: OwinStartup(typeof(MyService.App_Start.Startup))]
    namespace MyService.App_Start {
        public class Startup {
            const string EnvironmentKey = "APP_ENVIRONMENT";
            const string PRODUCTION = "Production";
            const string TEST = "Test";
            
            public void Configuration(IAppBuilder app) {
                string ENVIRONMENT = ConfigurationManager.AppSettings[EnvironmentKey] 
                                        ?? Production;
                if(ENVIRONMENT == TEST) {
                    var config = new HttpConfiguration();
                    WebApiConfig.Register(config);
                    app.UseWebApi(config);
                } else {
                    GlobalConfiguration.Configure(WebApiConfig.Register);
                }
            }
        }
    }
    

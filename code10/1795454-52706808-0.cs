    public class WebApiApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            //REMOVE THIS AND LET OWIN STARTUP HANDLE SETUP
            //GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }

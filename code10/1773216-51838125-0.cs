    public class StartupHandler : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication,
            ApplicationContext applicationContext)
        {
            base.ApplicationStarted(umbracoApplication, applicationContext);
    
            //Set a global variable/information to make sure that the Umbraco is ready
            Setting.UmbracoIsReady = true;
        }
    }

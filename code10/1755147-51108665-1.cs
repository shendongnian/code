    public class iOSInitializer : IPlatformInitalizer, IConfiguration
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistery.RegisterInstance<IConfiguration>(this);
        }
    }

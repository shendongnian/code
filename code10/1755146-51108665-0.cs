    public class iOSInitializer : IPlatformInitalizer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistery.RegisterInstance<IConfiguration>(new iOSConfiguration());
        }
    }

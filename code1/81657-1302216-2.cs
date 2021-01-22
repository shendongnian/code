    public class PlatformServicesFacade
    {
        private static readonly IPlatformServices services;
        static PlatformServiceFacade()
        {
            services = RunningOnWindows() ? new WindowsPlatformServices()
                : new MonoPlatformServices();
        }
        public static void InitializeSystemMenu()
        {
            services.InitializeSystemMenu();
        }
    }

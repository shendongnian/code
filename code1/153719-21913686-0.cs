    public static IWindsorInstaller[] MobileRestComponentInstallers
            {
                get
                {
                    return new []
                               {
                                     new RepositoryInstaller(),
                                     new AppSettingsInstaller(),
                                     // tens of other installers...
                                     GetLoggerInstaller() // public IWindsorInstaller GetLoggerInstaller()...
                               };
                }
            }

    public static class ServiceProvider
    {
         public static IServiceProvider BuildServiceProvider(IServiceCollection services) => services
              .BuildDependencies()
              .BuildServiceProvider();
    }

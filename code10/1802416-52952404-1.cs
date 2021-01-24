    public class ApplicationProvider
    {
         public ApplicationProvider() => Configuration = ApplicationConfigurationProvider.BuildConfigurationProvider();
    
         public void StartApplication()
         {
              var serviceCollection = new ServiceCollection().AddSingleton(configuration => Configuration);
              var serviceProvider = ApplicationServiceProvider.BuildServiceProvider(serviceCollection);
    
              ...
         }
    }

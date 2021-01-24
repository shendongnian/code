    public class UnitTestStartup : Startup
        {
            public static IServiceProvider ServiceProvider;
            public static IServiceCollection Services;
            public static Mock<IConstants> ConstantsMock; 
   
    public void ConfigureTestingServices(IServiceCollection services)
        {
            
            ServiceProvider = base.ConfigureServices(services);
            Services = services;
            ConstantsMock = new Mock<IConstants>();
            
            services.Replace(new ServiceDescriptor(typeof(IConstants), ConstantsMock.Object));
        }
    }

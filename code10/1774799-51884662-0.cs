    // Services that implement IDisposable:
    public class Service1 : IDisposable {}
    public class Service2 : IDisposable {}
    public class Service3 : IDisposable {}
    public class SomeServiceImplementation : ISomeService, IDisposable {}
    public void ConfigureServices(IServiceCollection services)
    {
        // The container creates the following instances and disposes them automatically:
        services.AddScoped<Service1>();
        services.AddSingleton<Service2>();
        services.AddSingleton<ISomeService>(sp => new SomeServiceImplementation());
        // The container doesn't create the following instances, so it doesn't dispose of
        // the instances automatically:
        services.AddSingleton<Service3>(new Service3());
        services.AddSingleton(new Service3());
    }

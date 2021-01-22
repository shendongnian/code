public partial class OutterClass
{
    // When OutterClass is initialized, this will force InnerClass1 to be initialized.
    private static int _innerClass1Touched = InnerClass1.TouchMe;
	
    public static class InnerClass1
    {
        public static int TouchMe = 0;
		
        static InnerClass1()
        {
            Console.WriteLine("InnerClassInitialized");
        }
    }
}
public partial class OutterClass
{
    // When OutterClass is initialized, this will force InnerClass2 to be initialized.
    private static int _innerClass2Touched = InnerClass2.TouchMe;
	
    public static class InnerClass2
    {
        public static int TouchMe = 0;
		
        static InnerClass2()
        {
            Console.WriteLine("InnerClass2Initialized");
        }
    }
}
`
Then, somewhere early in your application, you just need to reference OutterClass in a way that will result in static initialization, like constructing an instance of it.
A more realistic example might be...
public interface IService
{
	void SayHello();
}
public partial class ServiceRegistry
{
	private static List<Func<IService>> _serviceFactories;
	
	private static void RegisterServiceFactory(Func<IService> serviceFactory)
	{
		// This has to be lazily initialized, because the order of static initialization
		//	isn't defined. RegisterServiceFactory could be called before _serviceFactories
		//  is initialized.
		if (_serviceFactories == null)
			_serviceFactories = new List<Func<IService>>();
			
		_serviceFactories.Add(serviceFactory);
	}
	
	public List<IService> Services { get; private set; }
	
	public ServiceRegistry()
	{
		Services = new List<IService>();
		
		foreach (var serviceFactory in _serviceFactories)
		{
			Services.Add(serviceFactory());
		}
	}
}
// In another file (ServiceOne.cs):
public class ServiceOne : IService
{
	void IService.SayHello()
	{
		Console.WriteLine("Hello from ServiceOne");
	}
}
public partial class ServiceRegistry
{
    // When OutterClass is initialized, this will force InnerClass1 to be initialized.
    private static int _serviceOneRegistryInitializer = ServiceOneRegistry.Initialize;
	
    private static class ServiceOneRegistry
    {
        public static int Initialize = 0;
		
        static ServiceOneRegistry()
        {
            ServiceRegistry.RegisterServiceFactory(() => new ServiceOne());
        }
    }
}
// In another file (ServiceTwo.cs):
public class ServiceTwo : IService
{
	void IService.SayHello()
	{
		Console.WriteLine("Hello from ServiceTwo");
	}
}
public partial class ServiceRegistry
{
    // When OutterClass is initialized, this will force InnerClass1 to be initialized.
    private static int _serviceTwoRegistryInitializer = ServiceTwoRegistry.Initialize;
	
    private static class ServiceTwoRegistry
    {
        public static int Initialize = 0;
		
        static ServiceTwoRegistry()
        {
            ServiceRegistry.RegisterServiceFactory(() => new ServiceTwo());
        }
    }
}
static void Main(string[] args)
{
	ServiceRegistry registry = new ServiceRegistry();
	foreach (var service in registry.Services)
	{
		serivce.SayHello();
	}
	
	// Output will be:
	// Hello from ServiceOne
	// Hello from ServiceTwo
	
	// No guarantee on order.
}
`
Why even do this? It has a very narrow use-case. It eliminates the need to have a single method that initializes and registers all the services.
The case in which I personally want to eliminate that single method initialization is for code generation purposes.

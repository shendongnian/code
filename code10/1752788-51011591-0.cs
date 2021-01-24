    class Program
    {
    	static void Main(string[] args)
    	{
    		var context = new SomeClass() { SomeId = 10 };
    		var container = ConfigureContainer(context);
    		var facadeInstance = container.Resolve<IFacade>();
    		Console.WriteLine(facadeInstance.ShowContextId());
    	}
    
    	public static IUnityContainer ConfigureContainer(SomeClass context)
    	{
    		IUnityContainer container = new UnityContainer();
    
    		container.RegisterType<IFacade, Facade>(new TransientLifetimeManager(), new InjectionConstructor(new InjectionParameter(typeof(SomeClass), context)));
    
    		return container;
    	}
    }
    
    public interface IFacade
    {
    	int ShowContextId();
    }
    
    public class Facade : IFacade
    {
    	public readonly SomeClass _context;
    
    	public Facade(SomeClass context)
    	{
    		_context = context;
    	}
    
    	public int ShowContextId() => _context?.SomeId ?? 0;
    }
    
    public class SomeClass
    {
    	public int SomeId { get; set; }
    }

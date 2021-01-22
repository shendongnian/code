    public interface IView { }
    public class View : IView { }
    public class View2 : IView { }
    
    public static class IckyStaticMonster
    {
    	public static IView Current { get; set;}
    }
    
    [TestFixture]
    public class configuring_concrete_types
    {
    	[Test]
    	public void TEST()
    	{
    		var container = new Container(cfg =>
    		{
    			cfg.Scan(scan =>
    			{
    				scan.TheCallingAssembly();
    				scan.Convention<ViewScanner>();
    			});
    		});
    
    		var current = new View2();
    		IckyStaticMonster.Current = current;
    
    		var view2 = container.GetInstance<View2>();
          
    		view2.ShouldBeTheSameAs(current);
    	}
    }
    
    public class ViewScanner : IRegistrationConvention
    {
    	public void Process(Type type, Registry registry)
    	{
    		Type _pluginType = typeof (IView);
    
    		if (_pluginType.IsAssignableFrom(type) && _pluginType.IsInterface)
    		{
    			registry.For(type).Use(c=>IckyStaticMonster.Current);
    		}
    	}
    }

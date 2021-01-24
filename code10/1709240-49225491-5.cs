    public class TestDataConfiguration
    {
    	public static IMyContext GetContex()
    	{
    		var serviceCollection = new ServiceCollection();
    		IocConfig.RegisterContext(serviceCollection, "", null);
    		var serviceProvider = serviceCollection.BuildServiceProvider();
    		return serviceProvider.GetService<IMyContext>();
    	}
    }
    	

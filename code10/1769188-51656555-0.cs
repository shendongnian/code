    public class Provider1Wrapper : IInterfaceWithOpenFunction
    {
    	private Provider1 _provider; // Instance\Inject via CTOR
    
    	public int Open(string stringName)
    	{
    		return _provider.Open(stringName);
    	}
    }
    
    public class Provider2Wrapper : IInterfaceWithOpenFunction
    {
    	private Provider2 _provider; // Instance\Inject via CTOR
    
    	public int Open(string stringName)
    	{
    		return _provider.Open(stringName);
    	}
    }
    
    public static class ProviderManager<T> where T : IInterfaceWithOpenFunction, new()
    {
        public static int Open(string stringName)
    	{
    		T providerWrapper = new T();
    		return providerWrapper.Open(stringName);
    	}
    }
    
    
    void Main()
    {
    	var result = ProviderManager<Provider2Wrapper>.Open(stringName);
    }

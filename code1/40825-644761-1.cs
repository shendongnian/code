    public class MyClassRepository
    {
    	IStorageProvider _provider;
    	public MyClassRepository(IStorageProvider provider)
    	{
    		_provider = provider;
    	}
    
    	public void Save(MyClass o)
    	{
    		_provider.Save(o);
    	}
    	
    	public MyClass GetBy(string id)
    	{
    		return _provider.GetBy(id);
    	}
    }

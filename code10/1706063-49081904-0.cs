    public class SomeGenericInterfaceAdapter<T> : INonGenericInterface
    {
    	private IGenericInterface<T> _someGenericInterface;
    	public SomeGenericInterfaceAdapter(IGenericInterface<T> someGenericInterface)
    	{
    		_someGenericInterface = someGenericInterface;
    	}
    
    	public void SomeMethod()
    	{
    		_someGenericInterface.SomeMethod();
    	}
    }
    
    public interface INonGenericInterface
    {
    	void SomeMethod();
    }
    
    public interface IGenericInterface<T>
    {
    	void SomeMethod();
    }

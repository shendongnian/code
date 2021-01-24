    public interface BaseInterface<T> where T : class
    {
    	T Method1(T u);
    }
    
    public class DerivedClass : BaseInterface<string>
    {
    	public string Method1(string u)
    	{
    		return "Some String";
    	}
    }

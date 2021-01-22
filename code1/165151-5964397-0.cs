    public interface IDerived
    {
    }
    public class BaseClass<T> where T : IDerived
    {
    	public static void Ping()
    	{
    		//here you have T = the derived type
    	}
    }
    public class DerivedClass : BaseClass<DerivedClass>, IDerived
    {
    }
    public class ExampleApp
    {
    	public void Main()
    	{
    		//here you can call the BaseClass's static method through DerivedClass
    		DerivedClass.Ping();    
    	}
    }

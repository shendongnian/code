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
        //with : BaseClass<DerivedClass> we are defining the T above
    }
    public class ExampleApp
    {
    	public void Main()
    	{
    		//here we can call the BaseClass's static method through DerivedClass
    		//and it will know what Type calls it
    		DerivedClass.Ping();    
    	}
    }

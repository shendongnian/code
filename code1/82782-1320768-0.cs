    public abstract class Person
    {
    }
    
    public class Employee : Person
    {
    }
    
    public class Customer : Person
    {
    }
    
    public class PersonRepository<T> : System.Collections.Generic.List<T> where T : Person
    {
    	public T Get( Guid id )
    	{
    		return null;
    	}
    }

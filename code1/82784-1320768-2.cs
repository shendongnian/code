    public interface IPerson
    {
    	public void DoSomething( ) { }
    }
    
    public abstract class Person:IPerson
    {
    	public void DoSomething( )
    	{
    		throw new NotImplementedException( );
    	}
    }
    
    public class Employee:Person 
    {
    	public void DoSomething( )
    	{
    		base.DoSomething( );
    		/* Put additional code here */
    	}
    }
    
    public class Customer : Person { }
    
    public class PersonRepository<T> : System.Collections.Generic.List<T> where T : IPerson, new()
    {
    	public T Get( Guid id )
    	{
    		IPerson person = new T( );
    		return (T)person;
    	}
    }

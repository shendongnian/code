    public interface IPerson
    {
    	void DoSomething( );
    }
    
    public abstract class Person : IPerson
    {
    
    	public virtual void DoSomething( )
    	{
    		throw new NotImplementedException( );
    	}
    }
    
    public class Employee : Person
    {
    	public override void DoSomething( )
    	{
    		base.DoSomething( );
    		/* Put additional code here */
    	}
    }
    
    public class Customer : Person { }
    
    public class PersonRepository<T> : System.Collections.Generic.List<T> where T : IPerson, new( )
    {
    	public T Get( Guid id )
    	{
    		IPerson person = new T( );
    		return (T)person;
    	}
    }

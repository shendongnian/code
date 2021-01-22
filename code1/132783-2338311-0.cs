    /// <summary>
    /// Interface used on the individual classes that controls 
    /// how the class will load it's data.
    /// </summary>
    public interface ILoadable
    {
     /// <summary>
     /// Again, I did not know what type of return value comes back from MyDataContext
     /// If the results are always of the same type or if they derive from the same 
     /// base class, then it makes it simpler. 
     /// </summary>
     void Load( ResultBaseClass result );
    }
    
    public class Job : ILoadable
    {
     public int Id { get; set; }
     public string Name { get; set; }
    
     public void Load( ResultBaseClass result )
     {
      var jobResult = result as up_GetJobResult;
      if ( jobResult == null )
       return;
      Id = jobResult.Id;
      Name = jobResult.Name;
     }
    }
    public static class MyDataContext
    {
     public static IList<ResultBaseClass> up_GetPerson( int id );
     public static IList<ResultBaseClass> up_GetJobResult( int id );
    }
    
    public class Person : ILoadable
    {
     public int Id { get; set; }
     public string Name { get; set; }
     public string Surname { get; set; }
    
     public void Load( ResultBaseClass result )
     {
      var personResult = result as up_GetPersonResult;
      if ( personResult == null )
       return;
      Id = personResult.Id;
      Name = personResult.Name;
      Surname = personResult.Surname;
     }
    }
    
    public abstract class MyProvider<T> where T : ILoadable, new()
    {
     /// <summary>
     /// Create a method only visible to derived classes which takes a delegate for the specific
     /// routine that should be called to retrieve data.
     /// </summary>
     protected List<T> Get( int id, Func<int, IList<ResultBaseClass>> getRoutine )
     {
      var result = new List<T>();
      foreach ( var resultInstance in getRoutine( id ) )
      {
       var item = new T();
       item.Load( resultInstance );
       result.Add( item );
      }
    
      return result;
     }
    }
    
    public class JobDataProvider : MyProvider<Job>
    {
     public List<Job> Get( int id )
     {
      return base.Get( id, MyDataContext.up_GetJobResult );
     }
    }
    public class PersonDataProvider : MyProvider<Person>
    {
     public List<Person> Get( int id )
     {
      return base.Get( id, MyDataContext.up_GetPerson );
     }
    }

    public interface IDataProvider
    {
      IEnumerable Get(int id);
    }
    public class JobDataProvider
      : IDataProvider
    {
      
      public List<Job> Get(int id)
      {
        var jobs = new List<Job>();
        // load jobs
        return jobs;
      }
      IEnumerable IDataProvider.Get(int id)
      {
        return Get(id);
      }
    }
    public class PersonDataProvider
      : IDataProvider
    {
      
      public List<Person> Get(int id)
      {
        var people = new List<Person>();
        // load people
        return people;
      }
      IEnumerable IDataProvider.Get(int id)
      {
        return Get(id);
      }
    }
    public class ItemDataProvider
    {
      private Dictionary<Type, IDataProvider> mProviders = new Dictionary<Type, IDataProvider>();
      public void RegisterProvider(Type type, IDataProvider provider)
      {
        mProviders.Add(type, provider);
      }
      public List<T> Get<T>(int id)
      {
        var data = mProviders[typeof(T)].Get(id);
        return (List<T>)data;
      }
    }
    public class Job
    {
    }
    public class Person
    {
    }

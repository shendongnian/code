    // generic mechanism through which the Get method can lookup a specific provider
    interface IDataProvider<T> {
      List<T> Get(int id);
    }
    
    // implement the generic interface
    public class JobDataProvider : IDataProvider<Job> {
      // existing stuff
    }
    
    // implement the generic interface
    public class PersondataProvider : IDataProvider<Person> {
      // existing stuff
    }
    // this class holds the method originally desired    
    public static class Helper {
      public static List<T> Get<T>(int id) {
        return Registry.Get<IDataProvider<T>>().Get(id);
      }
    }
    
    // this functions as the glue/mapping between type parameters
    // and specific, concrete data providers
    public static class Registry {
      private static Dictionary<Type, Func<object>> _entries; 
     
      public static T Get<T>() where T: class {
        return _entries[typeof(T)]() as T;
      }
    
      public static void Register<T>(Func<T> item) {
        _entries.Add(typeof(T), () => item() as object);
      }
    }

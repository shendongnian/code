    interface IDataProvider<T> {
      List<T> Get(int id);
    }
    
    public class JobDataProvider : IDataProvider<Job> {
      // existing stuff
    }
    
    public class PersondataProvider : IDataProvider<Person> {
      // existing stuff
    }
    
    public static class Helper {
      public static List<T> Get<T>(int id) {
        return Registry.Get<IDataProvider<T>>().Get(id);
      }
    }
    
    public static class Registry {
      private static Dictionary<Type, Func<object>> _entries; 
     
      public static T Get<T>() where T: class {
        return _entries[typeof(T)]() as T;
      }
    
      public static void Register<T>(Func<T> item) {
        _entries.Add(typeof(T), () => item() as object);
      }
    }

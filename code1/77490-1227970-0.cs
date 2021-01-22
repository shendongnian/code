    public class CustomStorage
    {
      private Dictionary<string, object> storage = new Dictionary<string, object>();
    
      public Remember(string key, object value)
      {
        storage[key] = value;
      }
    
      public object Retrieve(string key)
      {
        object x = storage[key];
        return x;
      }
    
      public U Retrieve<U>(string key)
      {
        U u = storage[key] as U;
        return u;
      }
    }

    public interface ISessionCache
    {
      T Get<T>(string key);
      void Set<T>(string key, T item);
      bool contains(string key);
      void clearKey(string key);
      T singleTon<T>(String key, getStuffAction<T> actionToPerform);
    }
    public class InMemorySessionCache : BaseSessionCache
    {
        Dictionary<String, Object> _col;
        public InMemorySessionCache()
        {
            _col = new Dictionary<string, object>();
        }
        public T Get<T>(string key)
        {
            return (T)_col[key];
        }
        public void Set<T>(string key, T item)
        {
            _col.Add(key, item);
        }
        public bool contains(string key)
        {
            if (_col.ContainsKey(key))
            {
                return true;
            }
            return false;
        }
        public void clearKey(string key)
        {
            if (contains(key))
            {
                _col.Remove(key);
            }
        }
    }
 
   
    public class HttpContextSessionCache : BaseSessionCache
    {
       private readonly HttpContext _context;
      public HttpContextSessionCache()
       {
          _context = HttpContext.Current;
       }
      public T Get<T>(string key)
       {
          object value = _context.Session[key];
          return value == null ? default(T) : (T)value;
       }
      public void Set<T>(string key, T item)
       {
          _context.Session[key] = item;
       }
       public bool contains(string key)
       {
           if (_context.Session[key] != null)
           {
              return true;
           }
           return false;
       }
       public void clearKey(string key)
       {
           _context.Session[key] = null;
       }
    }
 

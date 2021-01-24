    public class BaseClass
    {
       public static ConcurrentDictionary<Type,int> Counter = new ConcurrentDictionary<Type, int>();
    
       public BaseClass()
       {
          Counter.AddOrUpdate(GetType(), 1, (type, i) => i + 1);
       }
    }

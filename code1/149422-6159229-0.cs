    public static class EnumerableExtensions
    {   
       public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
       {
          foreach (var item in collection)
    	  {
    	     action(item);
          }
       }
       
       public static IEnumerable<T> Once<T>(this IEnumerable<T> collection, 
          Func<IEnumerable<T>, bool> predicate, Action<IEnumerable<T>> action)
       {
          if (predicate(collection)) 
    	     action(collection);
          return collection;
       }
    
       public static IEnumerable<T> ForEvery<T>(this IEnumerable<T> collection,
          Func<T, bool> predicate, Action<T> action)
       {
          foreach (var item in collection)
          {
             if (predicate(item)) 
                action(item);
          }
          return collection;
       }
    }

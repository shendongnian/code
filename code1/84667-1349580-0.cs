    public static IEnumerable<T> LoopWithExclusion<T>(this IEnumerable<T> list, Func<T,bool> excludePredicate)
    {
       foreach(var item in list)
       {
          if(excludePredicate(item))
          {
             continue;
          }
    
          yield return item;
       }
    }

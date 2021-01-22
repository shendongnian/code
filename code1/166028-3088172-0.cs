    public static class Extensions
    {
       public static void ForEachWithNull<T>(this IEnumerable<T> source, Action<T> action)
       {
          if(source == null)
          {
             return;
          }
          
          foreach(var item in source)
          {
             action(item);
          }
       }
    }

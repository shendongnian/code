    public static class EnumerableExtension
    {
       public static void IfEmpty<T>(this IEnumerable<T> list, Action<IEnumerable<T>> action)
       {
           if (list.Count() == 0)
             action(list);
       }
    }
    
    foreach (var v in blabla)
    {
    }
    blabla.IfEmpty(x => log("List is empty"));

    public static void Remove<T>(this IList list)
    {
         Type type = typeof(T);
         var itemsToRemove = list.Cast<object>.Where(o => o.GetType() == type).ToList();
         foreach(var item in itemsToRemove)
         {
              list.Remove(item);
         }
    }

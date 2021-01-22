    public static class ObjectSetExtensions
    {
         public static void AddObjects<T>(this ObjectSet<T> objectSet, IEnumerable<T> objects)
         {
             foreach (var item in objects)
             {
                objectSet.AddObject(item);
             }
         }
    }

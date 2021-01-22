     static IEnumerable<T> GetUniques<T>(IEnumerable<T> things)
     {
         Dictionary<T, bool> uniques = new Dictionary<T, bool>();
         foreach (T item in things)
         {
             if (!(uniques.ContainsKey(item)))
             {
                 uniques.Add(item, true);
             }
         }
         return uniques.Keys;
     }

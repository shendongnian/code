     public static void Reconcile<T, TKey>(
         this BindingList<T> left,
         BindingList<T> right,
         Func<T, TKey> keySelector)
     {
         var leftDict = left.ToDictionary(l => keySelector(l));
         
         foreach (var r in right)
         {
             var key = keySelector(r);
             T l;
             if (leftDict.TryGetValue(key, out l))
             {
                  // copy properties from r to l
                  ...
                  leftDict.RemoveKey(key);
             }
             else
             {
                  left.Add(r);
             }
         }
         foreach (var key in leftDict.Keys)
         {
             left.RemoveKey(key);
         }
     }

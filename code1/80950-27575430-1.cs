     public static int IndexOf<T>(this IEnumerable<T> source, Func<T, bool> predicate)
     {
         int retval = -1;
         var enumerator = source.GetEnumerator();
         while (enumerator.MoveNext())
         {
             retval += 1;
             if (predicate(enumerator.Current))
             {
                 IDisposable disposable = enumerator as System.IDisposable;
                 if (disposable != null) disposable.Dispose();
                 return retval;
             }
         }
         IDisposable disposable = enumerator as System.IDisposable;
         if (disposable != null) disposable.Dispose();
         return -1;
     }

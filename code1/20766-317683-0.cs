      public static class FuncUtils
      {
          public delegate T Func<T>();
          public delegate T Func<A0, T>(A0 arg0);
          public delegate T Func<A0, A1, T>(A0 arg0, A1 arg1);
          ... 
            
          public static IEnumerable<T> Filter<T>(IEnumerable<T> e, Func<T, bool> filterFunc)
          {
              foreach (T el in e)
                  if (filterFunc(el)) 
                      yield return el;
          }
    
          
          public static IEnumerable<R> Map<T, R>(IEnumerable<T> e, Func<T, R> mapFunc)
          {
              foreach (T el in e) 
                  yield return mapFunc(el);
          }
            ...

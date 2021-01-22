      public static class BatchExecuteExtension
      {
        public static void BatchExecute<T>(this IEnumerable<T> list, Action<T> action)
        {
          foreach (T obj in list)
          {
            action(obj);
          }
        }
      }

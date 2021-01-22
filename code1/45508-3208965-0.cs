      public static class LinqExtensions
      {
        public static void Each<T>(this IEnumerable<T> source, Action<T> method)
        {
          foreach (var item in source)
          {
            method(item);
          }
        }
      }

      public static class Extensions
      {
        public static void ForEach<T>(this IEnumerable source, Action<T> action)
        {
          foreach (var item in source)
          {
            action((T)item);
          }
        }
      }

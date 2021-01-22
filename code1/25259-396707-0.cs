      static class LogExtension
      {
        public static IEnumerable<Double> Log(this IEnumerable<int> list)
        {
          foreach (int i in list)
          {
            yield return Math.Log(i);
          }
        }
      }

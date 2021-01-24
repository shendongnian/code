    public static class EnumerableExtensions
    {
        public static bool HasAtLeast<T>(this IEnumerable<T> enumerable, int n)
        {
            var i = 0;
            foreach(var item in enumerable)
            {
              if(++i == n)
                  return true;
            }
            return false;
        }
    }

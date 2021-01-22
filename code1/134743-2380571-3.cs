    static class PagingUtils {
      public static IEnumerable<T> Page<T>(this IEnumerable<T> en, int pageSize, int page) {
        return en.Skip(page * pageSize).Take(pageSize);
      }
      public static IQueryable<T> Page<T>(this IQueryable<T> en, int pageSize, int page) {
        return en.Skip(page * pageSize).Take(pageSize);
      }
    }

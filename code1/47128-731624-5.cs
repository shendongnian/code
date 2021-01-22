    public static class LinqExtensions {
      public IQueriable<T> CondWhere<T>(this IQueriable<T> query, bool condition, Expression<Func<T,bool>> predicate) {
         if (condition)
            return query.Where(predicate);
         else 
            return query;
      }
     }

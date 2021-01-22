    public static class IQueryableExtensions {
 
      public static IQueryable<T> ContainsText<T>(this IQueryable<T> source, Expression<Func<T, string>> selector, string text) {
        if (source == null) {
          throw new ArgumentNullException();
        }
        if (text.IsNullOrEmpty()) {
          return source;
        }
        string propName = ((MemberExpression)selector.Body).Member.Name;
        return source.Where(ExpressionBuilder.ContainsText<T>(propName, text));
      }
    
    }

    public static class ExpressionBuilder {
      public static Expression<Func<T, bool>> ContainsText<T>(string propertyName, string text) {
        var paramExp = Expression.Parameter(typeof(T), "type");
        var propExp = Expression.Property(paramExp, propertyName);
        var methodInfo = typeof(string).GetMethod("Contains", new[] { typeof(string) });
        var valueExp = Expression.Constant(text, typeof(string));
        var methCall = Expression.Call(propExp, methodInfo, valueExp);
        return Expression.Lambda<Func<T, bool>>(methCall, paramExp);
      }
    }

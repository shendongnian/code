    private static string GetPropertyName<TSource, TResult>(Expression<Func<TSource, TResult>> expression)
    {
      if (expression.NodeType == ExpressionType.Lambda && expression.BodyType == ExpressionType.MemberAccess)
      {
        PropertyInfo pi = (expression.Body as MemberExpression).Member as PropertyInfo;
        if (pi != null)
        {
          return pi.Name;
        }
      }
      throw new ArgumentException("expression", "Not a property expression.");
    }

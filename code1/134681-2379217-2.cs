    public static bool IsMethod<TResult>(
      MethodInfo method, 
      Expression<Func<TResult>> expression)
    {
      // I think this doesn't work like this, evaluate static method call
      return method == ((MemberExpression)expression.Body).Member;
    }
    
    if (IsMethod(expr.Method, () => SqlFilterExtensions.Like))
    {
      // generate SQL
    }

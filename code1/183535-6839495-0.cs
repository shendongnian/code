    private MethodInfo ConcatMethod = typeof(string).GetMethod("Concat", new Type[] { typeof(string), typeof(string) });
    private MethodInfo ConcatMethod2 = typeof(Program).GetMethod("Concat", new Type[] { typeof(string), typeof(int) });
    public static string Concat(string obj1, int obj2)
    {
      return string.Concat(obj1, obj2.ToString());
    }
    private Expression SomeCode(string leftStr, string rightStr)
    {
      Expression left = Expression.Constant(leftStr);
      Expression right = Expression.Constant(rightStr);
      return Expression.Add(left, right, ConcatMethod);
    }
    private Expression SomeCode(string leftStr, int rightInt)
    {
      Expression left = Expression.Constant(leftStr);
      Expression right = Expression.Constant(rightInt);
      return Expression.Add(left, right, ConcatMethod2);
    }
    static void CheesyTest2()
    {
      Program foo = new Program();
      Expression exp = foo.SomeCode("abc", "def");
      LambdaExpression lambdaExpression = Expression.Lambda(exp);
      Delegate func = lambdaExpression.Compile();
      object result = func.DynamicInvoke();
      Console.WriteLine(string.Format("Expression result: {0}", result));
      exp = foo.SomeCode("abc", 42);
      lambdaExpression = Expression.Lambda(exp);
      func = lambdaExpression.Compile();
      result = func.DynamicInvoke();
      Console.WriteLine(string.Format("Expression2 result: {0}", result));
    }

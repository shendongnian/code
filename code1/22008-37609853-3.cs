    internal static MethodCallReturn<T, TProperty> SetupGet<T, TProperty>(Mock<T> mock, Expression<Func<T, TProperty>> expression, Condition condition) where T : class
    {
      return PexProtector.Invoke<MethodCallReturn<T, TProperty>>((Func<MethodCallReturn<T, TProperty>>) (() =>
      {
        if (ExpressionExtensions.IsPropertyIndexer((LambdaExpression) expression))
          return Mock.Setup<T, TProperty>(mock, expression, condition);
        ...
      }
      ...
    }

    public bool IsSummable(Type type)
    try
    {
      ParameterExpression paramA = Expression.Parameter(type, "a"), paramB = Expression.Parameter(type, "b");
      BinaryExpression addExpression = Expression.Add(paramA, paramB);
      var add = Expression.Lambda(addExpression, paramA, paramB).Compile();
      var v = Activator.CreateInstance(type);
      add.DynamicInvoke(v, v);
      return true;
    }
    catch
    {
      return false;
    }
    }

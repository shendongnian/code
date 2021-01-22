    public bool IsAveragable(Type type)
    try
    {
      ParameterExpression paramA = Expression.Parameter(type, "a"), paramB = Expression.Parameter(type, "b");
			// add the parameters together
			BinaryExpression addExpression = Expression.Add(paramA, paramB);
			var avg = Expression.Parameter(typeof(int), "b");
			var conv  = Expression.Convert(avg,type);
			BinaryExpression divideExpression = Expression.Divide(paramA, conv);
			// compile it
			var add = Expression.Lambda(addExpression, paramA, paramB).Compile();
			var divide = Expression.Lambda(divideExpression, paramA, avg).Compile();
			var v = Activator.CreateInstance(type);
			add.DynamicInvoke(v, v);
			divide.DynamicInvoke(v, 1);
                        return true;
    }
    catch
    {
      return false;
    }
    }

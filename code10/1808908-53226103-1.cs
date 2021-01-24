      public void DoSomething<TU, TV>(Expression<Func<TU, TV>> valueGetterExpr)
      {
        var expr = valueGetterExpr.Body;
        var li = new List<PropertyInfo>();
        while (!(expr is ParameterExpression))
        {
          if (!(expr is MemberExpression me))
            throw new Exception("Unexpected kind");
          if (!(me.Member is PropertyInfo pi))
            throw new Exception("Unexpected kind");
          li.Add(pi);
          expr = me.Expression;
        }
        // now 'li' holds all the properties
      }

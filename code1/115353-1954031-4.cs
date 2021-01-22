    public static class Member
    {
      private static string GetMemberName(Expression expression)
      {
        switch (expression.NodeType)
        {
          case ExpressionType.MemberAccess: var memberExpression = (MemberExpression)expression; var supername = GetMemberName(memberExpression.Expression); if (String.IsNullOrEmpty(supername)) return memberExpression.Member.Name; return String.Concat(supername, '.', memberExpression.Member.Name);
          case ExpressionType.Call: var callExpression = (MethodCallExpression)expression; return callExpression.Method.Name;
          case ExpressionType.Convert: var unaryExpression = (UnaryExpression)expression; return GetMemberName(unaryExpression.Operand);
          case ExpressionType.Parameter: return String.Empty;
          default: throw new ArgumentException("The expression is not a member access or method call expression");
        }
      }
      public static string Name<T,V>(Expression<Func<T, V>> expression)
      {
        return GetMemberName(expression.Body);
      }
      public static string Name<T>(Expression<Action<T>> expression)
      {
        return GetMemberName(expression.Body);
      }
    }
    void Copy<D, S, V>(D dest, S source, Expression<Func<S, V>> getVal, Action<D, V> setVal, IDictionary validationDictionary)
    {
      Func<S, V> doGetVal = getVal.Compile();
      try { setVal(dest, (V)doGetVal(source)); }
      catch (System.Exception exception)
      {
        validationDictionary.Add(Member.Name<S,V>(getVal), exception.Message);
      }
    }
    class TestAsset { public string AssetTag { get; set; } public string LocationIdentifier { get; set; } }
    TestAsset Test()
    {
      Dictionary<string, string> validationDictionary = new Dictionary<string, string>();
      var result = new TestAsset{ AssetTag = "a", LocationIdentifier = "b" };
      var asset = new TestAsset{ AssetTag = "A", LocationIdentifier = "B" };
      var validationCount = validationDictionary.Count(); 
      Copy(result, asset, x => asset.AssetTag, (x, v) => x.AssetTag = v, validationDictionary); 
      Copy(result, asset, x => asset.LocationIdentifier, (x, v) => x.LocationIdentifier = v, validationDictionary); 
      if (validationCount < validationDictionary.Count) throw new ArgumentException("Failed validation"); 
      return result;
    }

    public class EqualityComparerImpl<T> : IEqualityComparer<T>
    {
      public static EqualityComparerImpl<T> Create(
        params Expression<Func<T, object>>[] properties) =>
        new EqualityComparerImpl<T>(properties);
    
      PropertyInfo[] _properties;
      EqualityComparerImpl(Expression<Func<T, object>>[] properties)
      {
        if (properties == null)
          throw new ArgumentNullException(nameof(properties));
    
        if (properties.Length == 0)
          throw new ArgumentOutOfRangeException(nameof(properties));
    
        var length = properties.Length;
        var extractions = new PropertyInfo[length];
        for (int i = 0; i < length; i++)
        {
          var property = properties[i];
          extractions[i] = ExtractProperty(property);
        }
        _properties = extractions;
      }
    
      public bool Equals(T x, T y)
      {
        if (ReferenceEquals(x, y))
          //covers both are null
          return true;
        if (x == null || y == null)
          return false;
        var len = _properties.Length;
        for (int i = 0; i < _properties.Length; i++)
        {
          var property = _properties[i];
          if (!Equals(property.GetValue(x), property.GetValue(y)))
            return false;
        }
        return true;
      }
    
      public int GetHashCode(T obj)
      {
        if (obj == null)
          return 0;
    
        var hashes = _properties
            .Select(pi => pi.GetValue(obj)?.GetHashCode() ?? 0).ToArray();
        return Combine(hashes);
      }
    
      static int Combine(int[] hashes)
      {
        int result = 0;
        foreach (var hash in hashes)
        {
          uint rol5 = ((uint)result << 5) | ((uint)result >> 27);
          result = ((int)rol5 + result) ^ hash;
        }
        return result;
      }
    
      static PropertyInfo ExtractProperty(Expression<Func<T, object>> property)
      {
        if (property.NodeType != ExpressionType.Lambda)
          throwEx();
    
        var body = property.Body;
        if (body.NodeType == ExpressionType.Convert)
          if (body is UnaryExpression unary)
            body = unary.Operand;
          else
            throwEx();
    
        if (!(body is MemberExpression member))
          throwEx();
    
        if (!(member.Member is PropertyInfo pi))
          throwEx();
    
        return pi;
    
        void throwEx() =>
          throw new NotSupportedException($"The expression '{property}' isn't supported.");
      }
    }

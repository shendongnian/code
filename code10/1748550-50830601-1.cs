    private static readonly Type[] _types = {
          typeof(string),
          typeof(decimal),
          typeof(DateTime),
          typeof(DateTimeOffset),
          typeof(TimeSpan),
          typeof(Guid)
       };
    public static bool IsSimpleType(Type type)
    {
       Type baseType;
       return type.IsPrimitive || 
              type.IsEnum || 
              _types.Contains(type) || 
              ((baseType = Nullable.GetUnderlyingType(type)) != null && 
               IsSimpleType(baseType));
    }

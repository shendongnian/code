    private static readonly Type[] _types = {
          typeof(Enum),
          typeof(string),
          typeof(decimal),
          typeof(DateTime),
          typeof(DateTimeOffset),
          typeof(TimeSpan),
          typeof(Guid)
       };
    public static bool IsSimpleType(Type type)
    {
       return type.IsPrimitive ||                             //
              _types.Contains(type) ||                        //
              Convert.GetTypeCode(type) != TypeCode.Object || //
              (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>) && 
                 IsSimpleType(type.GetGenericArguments()[0]));
    }

    public static class TypeExtensions
    {
      public static bool IsNullableType(this Type type)
      {
        return type.IsGenericType 
        && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
      }

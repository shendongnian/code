     public static bool IsNullableType(this Type nullableType) =>
        // instantiated generic type only                
        nullableType.IsGenericType &&
        !nullableType.IsGenericTypeDefinition &&
        Object.ReferenceEquals(nullableType.GetGenericTypeDefinition(), typeof(Nullable<>));

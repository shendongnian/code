    /// <summary>
    ///     Check whether the specified type is enumerable.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="underlyingType">IEnumerable{int} would be int</param>
    /// <param name="excludeString">
    ///  [OPTIONAL] if set to <c>true</c> [exclude string]. Strings are enumerable as char[]
    ///  this is likely not something you want. Default is true (string will return false)
    /// </param>
    /// <returns><c>true</c> supplied type is enumerable otherwise <c>false</c></returns>
    public static bool IsEnumerable(this Type type, out Type underlyingType, 
        bool excludeString = true) 
    {
        underlyingType = null;
        if (type.IsEnum || type.IsPrimitive || type.IsValueType) return false;
        if (excludeString && type == typeof(string)) return false;
        if (type.IsGenericType)
        {
            if (type.GetGenericTypeDefinition() == typeof(IEnumerable<>) ||
                type.GetInterfaces().Any(t => t == typeof(IEnumerable<>) || 
                  (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>)))) 
            {
                underlyingType = type.GetGenericArguments()[0];
                return true;
            }
        }
        var enumerableOrNull = type.GetInterfaces().FirstOrDefault(t => t.IsGenericType && 
              t.GetGenericTypeDefinition() == typeof(IEnumerable<>));
        if (enumerableOrNull == null) return false;
        underlyingType = enumerableOrNull.GetGenericArguments()[0];
        return true;
    }

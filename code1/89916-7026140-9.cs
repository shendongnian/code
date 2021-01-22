    internal static Type[] ConvertibleTypes = {typeof(bool), typeof(byte), typeof(char),
       typeof(DateTime), typeof(decimal), typeof(double), typeof(float), typeof(int), 
       typeof(long), typeof(sbyte), typeof(short), typeof(string), typeof(uint), 
       typeof(ulong), typeof(ushort)};
    /// <summary>
    /// Returns true if this Type matches any of a set of Types.
    /// </summary>
    /// <param name="type">This type.</param>
    /// <param name="types">The Types to compare this Type to.</param>
    public static bool In(this Type type, params Type[] types) 
    { 
       foreach (Type t in types) if (t.IsAssignableFrom(type)) return true; return false; 
    }
    /// <summary>
    /// Returns true if this Type is one of the types accepted by Convert.ToString() 
    /// (other than object).
    /// </summary>
    public static bool IsConvertible(this Type t) { return t.In(ConvertibleTypes); }
    /// <summary>
    /// Gets whether this type is enumerable.
    /// </summary>
    public static bool IsEnumerable(this Type t) 
    { 
       return typeof(IEnumerable).IsAssignableFrom(t); 
    }
    /// <summary>
    /// Returns true if this property's getter is public, has no arguments, and has no 
    /// generic type parameters.
    /// </summary>
    public static bool SimpleGetter(this PropertyInfo info) 
    { 
       MethodInfo method = info.GetGetMethod(false); 
       return method != null && method.GetParameters().Length == 0 && 
          method.GetGenericArguments().Length == 0; 
    }

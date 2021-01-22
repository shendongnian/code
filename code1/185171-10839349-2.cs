    public static bool CanAssignValue(this PropertyInfo p, object value)
    {
        return value == null ? p.IsNullable() : p.PropertyType.IsInstanceOfType(value);
    }
    
    public static bool IsNullable(this PropertyInfo p)
    {
        return p.PropertyType.IsNullable();
    }
    
    public static bool IsNullable(this Type t)
    {
        return !t.IsValueType || Nullable.GetUnderlyingType(t) != null;
    }

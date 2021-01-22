    public static bool IsNullableType(Type valueType)
    {
        return (valueType.IsGenericType && 
            valueType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)));
    }
    public static T GetValue<T>(this IDataReader reader, string columnName)
    {
        object value = reader[columnName];
        Type valueType = typeof(T);
        if (value != DBNull.Value)
        {
            if (!IsNullableType(valueType))
            {
                return (T)Convert.ChangeType(value, valueType);
            }
            else
            {
                NullableConverter nc = new NullableConverter(valueType);
                return (T)Convert.ChangeType(value, nc.UnderlyingType);
            }
        }            
        return default(T);
    }

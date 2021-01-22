    /// <summary>
    /// Gets the equivalent SQL data type of the given type.
    /// </summary>
    /// <param name="type">Type to get the SQL type equivalent of</param>
    public static SqlDbType GetSqlType(Type type)
    {
        if (type == typeof(string))
            return SqlDbType.NVarChar;
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            type = Nullable.GetUnderlyingType(type);
        var param = new SqlParameter("", Activator.CreateInstance(type));
        return param.SqlDbType;
    }

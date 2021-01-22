    public static object DbNullable<T>(T? value) where T : struct
    {
        if (value.HasValue)
        {
            return value.Value;
        }
        return DBNull.Value;
    }
    public static object ToDbNullable<T>(this T? value) where T : struct
    {
        return DbNullable(value);
    }

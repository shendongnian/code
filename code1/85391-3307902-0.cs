    public static T Def<T>(this SqlDataReader r, int ord)
    {
        var t = r.GetSqlValue(ord);
        if (t == DBNull.Value) return default(T);
        return ((INullable)t).IsNull ? default(T) : (T)t;
    }
    public static T? Val<T>(this SqlDataReader r, int ord) where T:struct
    {
        var t = r.GetSqlValue(ord);
        if (t == DBNull.Value) return null;
        return ((INullable)t).IsNull ? (T?)null : (T)t;
    }
    public static T Ref<T>(this SqlDataReader r, int ord) where T : class
    {
        var t = r.GetSqlValue(ord);
        if (t == DBNull.Value) return null;
        return ((INullable)t).IsNull ? null : (T)t;
    }

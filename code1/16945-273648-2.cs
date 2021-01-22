    public static int? GetNullableInt32(this IDataRecord dr, int ordinal)
    {
        int? nullInt = null;
        return dr.IsDBNull(ordinal) ? nullInt : dr.GetInt32(ordinal);
    }
    public static int? GetNullableInt32(this IDataRecord dr, string fieldname)
    {
        int ordinal = dr.GetOrdinal(fieldname);
        return dr.GetNullableInt32(ordinal);
    }
    public static bool? GetNullableBoolean(this IDataRecord dr, int ordinal)
    {
        bool? nullBool = null;
        return dr.IsDBNull(ordinal) ? nullBool : dr.GetBoolean(ordinal);
    }
    public static bool? GetNullableBoolean(this IDataRecord dr, string fieldname)
    {
        int ordinal = dr.GetOrdinal(fieldname);
        return dr.GetNullableBoolean(ordinal);
    }

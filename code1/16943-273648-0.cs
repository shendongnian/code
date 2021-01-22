    public static DateTime? GetNullableDateTime(this MySqlDataReader dr, string fieldName)
    {
        DateTime? nullDate = null;
        return dr.IsDBNull(dr.GetOrdinal(fieldName)) ? nullDate : dr.GetDateTime(fieldName);
    }
    public static string GetNullableString(this MySqlDataReader dr, string fieldName)
    {
        return dr.IsDBNull(dr.GetOrdinal(fieldName)) ? String.Empty : dr.GetString(fieldName);
    }
    public static char? GetNullableChar(this MySqlDataReader dr, string fieldName)
    {
        char? nullChar = null;
        return dr.IsDBNull(dr.GetOrdinal(fieldName)) ? nullChar : dr.GetChar(fieldName);
    }

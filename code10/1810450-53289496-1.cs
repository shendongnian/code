    public static int? GetNullableInt32(this SqlDataReader dataReader, int ordinal)
    {
        return dataReader.IsDBNull(ordinal))
            ? (int?)null
            : dataReader.GetInt32(ordinal);
    }

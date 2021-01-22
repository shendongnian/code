    public static T? GetNullableValueType<T>(this SqlDataReader sqlDataReader, string columnName) where T : struct
    {
        int columnOrdinal = sqlDataReader.GetOrdinal(columnName);
        return sqlDataReader.IsDBNull(columnOrdinal) ? (T?)null : sqlDataReader.GetFieldValue<T>(columnOrdinal);
    }
    public static T GetNullableReferenceType<T>(this SqlDataReader sqlDataReader, string columnName) where T : class
    {
        int columnOrdinal = sqlDataReader.GetOrdinal(columnName);
        return sqlDataReader.IsDBNull(columnOrdinal) ? null : sqlDataReader.GetFieldValue<T>(columnOrdinal);
    }
    public static T GetNonNullValue<T>(this SqlDataReader sqlDataReader, string columnName)
    {
        int columnOrdinal = sqlDataReader.GetOrdinal(columnName);
        return sqlDataReader.GetFieldValue<T>(columnOrdinal);
    }

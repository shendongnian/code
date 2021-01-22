    public static class SQLDataReaderExtensions
        {
            public static int SafeGetInt(this SqlDataReader dataReader, string fieldName)
            {
                int fieldIndex = dataReader.GetOrdinal(fieldName);
                return dataReader.IsDBNull(fieldIndex) ? 0 : dataReader.GetInt32(fieldIndex);
            }
    
            public static int? SafeGetNullableInt(this SqlDataReader dataReader, string fieldName)
            {
                int fieldIndex = dataReader.GetOrdinal(fieldName);
                return dataReader.GetValue(fieldIndex) as int?;
            }
    
            public static string SafeGetString(this SqlDataReader dataReader, string fieldName)
            {
                int fieldIndex = dataReader.GetOrdinal(fieldName);
                return dataReader.IsDBNull(fieldIndex) ? string.Empty : dataReader.GetString(fieldIndex);
            }
    
            public static DateTime? SafeGetNullableDateTime(this SqlDataReader dataReader, string fieldName)
            {
                int fieldIndex = dataReader.GetOrdinal(fieldName);
                return dataReader.GetValue(fieldIndex) as DateTime?;
            }
    
            public static bool SafeGetBoolean(this SqlDataReader dataReader, string fieldName)
            {
                return SafeGetBoolean(dataReader, fieldName, false);
            }
    
            public static bool SafeGetBoolean(this SqlDataReader dataReader, string fieldName, bool defaultValue)
            {
                int fieldIndex = dataReader.GetOrdinal(fieldName);
                return dataReader.IsDBNull(fieldIndex) ? defaultValue : dataReader.GetBoolean(fieldIndex);
            }
        }

    static class DataReaderExtensions
    {
        public static string GetStringOrNull(this IDataReader reader, int ordinal)
        {
            return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);
        }
        public static string GetStringOrNull(this IDataReader reader, string columnName)
        {
            return reader.IsDBNull(columnName) ? null : reader.GetString(columnName);
        }
    }

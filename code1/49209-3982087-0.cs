    public static class DataReaderExtensions
    {
        public static bool IsDBNull( this IDataReader dataReader, string columnName )
        {
            return dataReader[columnName] == DBNull.Value;
        }
    }

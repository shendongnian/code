    public static class DataReaderExtensions
    {
        public static string GetNullableString(this SqlDataReader dataReader, int ordinal)
        {
            return dataReader.IsDBNull(ordinal))
                ? (string)null
                : dataReader.GetString(ordinal);
        }
    }

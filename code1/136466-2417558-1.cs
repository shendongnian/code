    public static class DataRecordExtensions
    {
        public static string GetStringSafely(this IDataRecord record, int index)
        {
            if (record.IsDBNull(index))
                return string.Empty;
             return record.GetString(index);            
        }
        public static Guid GetGuidSafely(this IDataRecord record, int index)
        {
            if (record.IsDBNull(index))
                return default(Guid);
            
            return record.GetGuid(index);
        }
        public static DateTime GetDateTimeSafely(this IDataRecord record, int index)
        {
            if (record.IsDBNull(index))
                return default(DateTime);
            return record.GetDateTime(index);
        }
    }

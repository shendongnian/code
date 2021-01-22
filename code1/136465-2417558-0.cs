    public static class DataRecordExtensions
    {
        public static string GetStringSafely(this IDataRecord record, int index)
        {
            if (!record.IsDBNull(index))
                return record.GetString(index);
            return string.Empty;
        }
        public static Guid GetGuidSafely(this IDataRecord record, int index)
        {
            if (!record.IsDBNull(index))
                return record.GetGuid(index);
            
            return default(Guid);
        }
        public static DateTime GetDateTimeSafely(this IDataRecord record, int index)
        {
            if (!record.IsDBNull(index))
                return record.GetDateTime(index);
            return default(DateTime);
        }
    }

    public static class DataRecordExtensions
    {
        public static string GetNullableString(this IDataRecord dataRecord, int ordinal)
        {
            return dataRecord.IsDBNull(ordinal) ? null : dataRecord.GetString(ordinal);
        }
    }

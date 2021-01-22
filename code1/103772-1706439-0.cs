    public static class DataRowExtensions
    {
        public static Nullable<T> GetNullableValue<T>(this DataRow row, string columnName)
            where T : struct
        {
            object value = row[columnName];
            if (Convert.IsDBNull(value))
                return null;
            return (Nullable<T>)value;
        }
        public static T GetValue<T>(this DataRow row, string columnName)
            where T : class
        {
            object value = row[columnName];
            if (Convert.IsDBNull(value))
                return null;
            return (T)value;
        }
    }

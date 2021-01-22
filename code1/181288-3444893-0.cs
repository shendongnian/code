    public static class DBNullExtensions
    {
        public static object AsDBNullIfEmpty(this string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return DBNull.Value;
            }
            return value;
        }
    }

        public static DateTime GetDateTime(this DbDataReader reader, string name)
        {
            int i = reader.GetOrdinal(name);
            return reader.GetDateTime(i);
        }
        public static decimal GetDecimal(this DbDataReader reader, string name)
        {
            int i = reader.GetOrdinal(name);
            return reader.GetDecimal(i);
        }
        public static double GetDouble(this DbDataReader reader, string name)
        {
            int i = reader.GetOrdinal(name);
            return reader.GetDouble(i);
        }
        public static string GetString(this DbDataReader reader, string name)
        {
            int i = reader.GetOrdinal(name);
            return reader.GetString(i);
        }
        ...

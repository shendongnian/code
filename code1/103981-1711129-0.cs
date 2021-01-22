        public static T Get<T>(this IDataReader reader, string columnName)
        {
            if (reader[columnName] == DbNull.Value)
            {
                return default(T);
            }
            return (T)reader[columnName];
        }

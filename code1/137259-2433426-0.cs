        public static T GetValueSafe<T>(this IDataReader dataReader, string columnName, Func<IDataReader, int, T> valueExtractor)
            where T : class 
        {
            T value;
            if (dataReader.TryGetValueSafe(columnName, valueExtractor, out value))
            {
                return value;
            }
            return null;
        }
        public static bool TryGetValueSafe<T>(this IDataReader dataReader, string columnName, Func<IDataReader, int, T> valueExtractor, out T value)
        {
            int ordinal = dataReader.GetOrdinal(columnName);
            if (!dataReader.IsDBNull(ordinal))
            {
                // Get value.
                value = valueExtractor.Invoke(dataReader, ordinal);
                return true;
            }
            value = default(T);
            return false;
        }

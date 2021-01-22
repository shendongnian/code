    public static class DataRecordExtensions {
        /// <summary>
        /// Generically extracts a field value by name from any IDataRecord as specified type. Will throw if DNE.
        /// </summary>
        public static T GetValue<T>(this IDataRecord row, string fieldName)
            => row.GetValue<T>(row.GetOrdinal(fieldName));
        /// <summary>
        /// Generically extracts a field value by ordinal from any IDataRecord as specified type. Will throw if DNE.
        /// </summary>
        public static T GetValue<T>(this IDataRecord row, int ordinal)
            => (T)row.GetValue(ordinal);
        /// <summary>
        /// Generically extracts a field value by name from any IDataRecord as specified type. Will return default generic types value if DNE.
        /// </summary>
        public static T GetValueOrDefault<T>(this IDataRecord row, string fieldName, T defaultValue = default(T))
            => row.GetValueOrDefault<T>(row.GetOrdinal(fieldName), defaultValue);
        /// <summary>
        /// Generically extracts a field value by ordinal from any IDataRecord as specified type. Will return default generic types value if DNE.
        /// </summary>
        public static T GetValueOrDefault<T>(this IDataRecord row, int ordinal, T defaultValue = default(T))
            => (T)(row.IsDBNull(ordinal) ? defaultValue : row.GetValue(ordinal));
    }

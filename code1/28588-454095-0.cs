    ///<summary>
    /// Extension methods for manipulating DataRows
    ///</summary>
    public static class DataRowUserExtensions
    {
        /// <summary>
        /// Determines whether [is null or empty string] [the specified data row].
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <param name="key">The key.</param>
        /// <returns>
        ///   <c>true</c> if [is null or empty string] [the specified data row]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmptyString(this DataRow dataRow, string key)
        {
            if (dataRow.Table.Columns.Contains(key))
                return dataRow[key] == null || dataRow[key] == DBNull.Value || dataRow[key].ToString() == string.Empty;
    
            throw new ArgumentOutOfRangeException(key, dataRow, "does not contain column");
        }
    
        /// <summary>
        /// Gets the specified data row.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataRow">The data row.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static T Get<T>(this DataRow dataRow, string key)
        {
            if (dataRow.Table.Columns.Contains(key))
                return dataRow.IsNullOrEmptyString(key) ? default(T) : (T) ChangeTypeTo<T>(dataRow[key]);
    
            throw new ArgumentOutOfRangeException(key, dataRow, "does not contain column");
        }
    
        /// <summary>
        /// Changes the type to.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private static object ChangeTypeTo<T>(this object value)
        {
            if (value == null)
                return null;
    
            Type underlyingType = typeof (T);
            if (underlyingType == null)
                throw new ArgumentNullException("value");
    
            if (underlyingType.IsGenericType && underlyingType.GetGenericTypeDefinition().Equals(typeof (Nullable<>)))
            {
                var converter = new NullableConverter(underlyingType);
                underlyingType = converter.UnderlyingType;
            }
    
            // Guid convert
            if (underlyingType == typeof (Guid))
            {
                return new Guid(value.ToString());
            }
    
            // Do conversion
            return underlyingType.IsAssignableFrom(value.GetType()) ?
                  Convert.ChangeType(value, underlyingType)
                : Convert.ChangeType(value.ToString(), underlyingType);
        }
    }

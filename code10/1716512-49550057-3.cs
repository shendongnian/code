    /// <summary>
    /// Provides extension methods for IDataReader.
    /// </summary>
    public static class IDataReaderExtensions
    {
        /// <summary>
        /// Gets the value of type T from the column specified by the index parameter, or default(T) if it's null.
        /// </summary>
        /// <typeparam name="T">The type of the value to get.</typeparam>
        /// <param name="reader">An instance of a class implementing IDataReader.</param>
        /// <param name="index">The index of the column from where to get the value.</param>
        /// <returns>The value of type T from the specified column, default(T) if null.</returns>
        public static T GetValueOrDefault<T>(this IDataReader reader, int index)
        {
            return (Convert.IsDBNull(reader[index])) ? default(T) : (T)reader.GetValue(index);
        }
        /// <summary>
        /// Gets the value of type T from the column specified by the name parameter, or default(T) if it's null.
        /// </summary>
        /// <typeparam name="T">The type of the value to get.</typeparam>
        /// <param name="reader">An instance of a class implementing IDataReader.</param>
        /// <param name="name">The name of the column from where to get the value.</param>
        /// <returns>The value of type T from the specified column, default(T) if null.</returns>
        public static T GetValueOrDefault<T>(this IDataReader reader, string name)
        {
            return reader.GetValueOrDefault<T>(reader.GetOrdinal(name));
        }
    }

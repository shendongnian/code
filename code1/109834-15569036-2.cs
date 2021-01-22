    /// <summary>
    /// Extentionclass for a nullable structs
    /// </summary>
    public static class NullableStructExtensions {
        /// <summary>
        /// Formats a nullable struct
        /// </summary>
        /// <param name="source"></param>
        /// <param name="format">The format string 
        /// If <c>null</c> use the default format defined for the type of the IFormattable implementation.</param>
        /// <param name="provider">The format provider 
        /// If <c>null</c> the default provider is used</param>
        /// <param name="defaultValue">The string to show when the source is <c>null</c>. 
        /// If <c>null</c> an empty string is returned</param>
        /// <returns>The formatted string or the default value if the source is <c>null</c></returns>
        public static string ToString<T>(this T? source, string format = null, 
                                         IFormatProvider provider = null, 
                                         string defaultValue = null) 
                                         where T : struct, IFormattable {
            return source.HasValue
                       ? source.Value.ToString(format, provider)
                       : (String.IsNullOrEmpty(defaultValue) ? String.Empty : defaultValue);
        }
    }

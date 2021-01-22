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
        public static string ToString<T>(this T? source, string format, 
                                         IFormatProvider provider, string defaultValue) 
                                         where T : struct, IFormattable {
            return source.HasValue
                       ? source.Value.ToString(format, provider)
                       : (String.IsNullOrEmpty(defaultValue) ? String.Empty : defaultValue);
        }
        /// <summary>
        /// Formats a nullable struct
        /// </summary>
        /// <param name="source"></param>
        /// <param name="format">The format string 
        /// If <c>null</c> use the default format defined for the type of the IFormattable implementation.</param>
        /// <param name="defaultValue">The string to show when the source is null. If <c>null</c> an empty string is returned</param>
        /// <returns>The formatted string or the default value if the source is <c>null</c></returns>
        public static string ToString<T>(this T? source, string format, string defaultValue) 
                                         where T : struct, IFormattable {
            return ToString(source, format, null, defaultValue);
        }
        /// <summary>
        /// Formats a nullable struct
        /// </summary>
        /// <param name="source"></param>
        /// <param name="format">The format string 
        /// If <c>null</c> use the default format defined for the type of the IFormattable implementation.</param>
        /// <param name="provider">The format provider (if <c>null</c> the default provider is used)</param>
        /// <returns>The formatted string or an empty string if the source is <c>null</c></returns>
        public static string ToString<T>(this T? source, string format, IFormatProvider provider)
                                         where T : struct, IFormattable {
            return ToString(source, format, provider, null);
        }
        /// <summary>
        /// Formats a nullable struct or returns an empty string
        /// </summary>
        /// <param name="source"></param>
        /// <param name="format">The format string 
        /// If <c>null</c> use the default format defined for the type of the IFormattable implementation.</param>
        /// <returns>The formatted string or an empty string if the source is null</returns>
        public static string ToString<T>(this T? source, string format)
                                         where T : struct, IFormattable {
            return ToString(source, format, null, null);
        }
        /// <summary>
        /// Formats a nullable struct
        /// </summary>
        /// <param name="source"></param>
        /// <param name="provider">The format provider (if <c>null</c> the default provider is used)</param>
        /// <param name="defaultValue">The string to show when the source is <c>null</c>. If <c>null</c> an empty string is returned</param>
        /// <returns>The formatted string or the default value if the source is <c>null</c></returns>
        public static string ToString<T>(this T? source, IFormatProvider provider, string defaultValue)
                                         where T : struct, IFormattable {
            return ToString(source, null, provider, defaultValue);
        }
        /// <summary>
        /// Formats a nullable struct or returns an empty string
        /// </summary>
        /// <param name="source"></param>
        /// <param name="provider">The format provider (if <c>null</c> the default provider is used)</param>
        /// <returns>The formatted string or an empty string if the source is <c>null</c></returns>
        public static string ToString<T>(this T? source, IFormatProvider provider)
                                         where T : struct, IFormattable {
            return ToString(source, null, provider, null);
        }
        /// <summary>
        /// Formats a nullable struct or returns an empty string
        /// </summary>
        /// <param name="source"></param>
        /// <returns>The formatted string or an empty string if the source is <c>null</c></returns>
        public static string ToString<T>(this T? source) 
                                         where T : struct, IFormattable {
            return ToString(source, null, null, null);
        }
    }

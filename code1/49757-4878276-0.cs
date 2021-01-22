        /// <summary>
        /// Converts a string to the specified nullable type.
        /// </summary>
        /// <typeparam name="T">The type to convert to</typeparam>
        /// <param name="s">The string to convert</param>
        /// <returns>The nullable output</returns>
        public static T? ToNullable<T>(this string s) where T : struct
        {
            if (string.IsNullOrWhiteSpace(s))
                return null;
            
            TypeConverter conv = TypeDescriptor.GetConverter(typeof (T));
            return (T) conv.ConvertFrom(s);
        }
        /// <summary>
        /// Attempts to convert a string to the specified nullable primative.
        /// </summary>
        /// <typeparam name="T">The primitive type to convert to</typeparam>
        /// <param name="data">The string to convert</param>
        /// <param name="output">The nullable output</param>
        /// <returns>
        /// True if conversion is successfull, false otherwise.  Null and whitespace will
        /// be converted to null and return true.
        /// </returns>
        public static bool TryParseNullable<T>(this string data, out T? output) where T : struct
        {
            try
            {
                output = data.ToNullable<T>();
                return true;
            }
            catch
            {
                output = null;
                return false;
            }
        }

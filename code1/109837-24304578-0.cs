    public static class Extensions
    {
        /// <summary>
        /// Generic method for format nullable values
        /// </summary>
        /// <returns>Formated value or defaultValue</returns>
        public static string ToString<T>(this Nullable<T> nullable, string format, string defaultValue = null) where T : struct
        {
            if (nullable.HasValue)
            {
                return String.Format("{0:" + format + "}", nullable.Value);
            }
            return defaultValue;
        }
    }

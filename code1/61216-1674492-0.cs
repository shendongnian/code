    public static class StringUtils
    {
        /// <summary>
        /// This method will parse a value from a string.
        /// If the string is null or not the right format to parse a valid value,
        /// it will return the default value provided.
        /// </summary>
        public static T To<t>(this string value, T defaultValue)
            where T: struct
        {
            var type = typeof(T);
            if (value != null)
            {
                var parse = type.GetMethod("TryParse", new Type[] { typeof(string), type.MakeByRefType() });
                var parameters = new object[] { value, default(T) };
                if((bool)parse.Invoke(null, parameters))
                    return (T)parameters[1];
            }
            return defaultValue;
        }
    
        /// <summary>
        /// This method will parse a value from a string.
        /// If the string is null or not the right format to parse a valid value,
        /// it will return the default value for the type.
        /// </summary>
        public static T To<t>(this string value)
            where T : struct
        {
            return value.To<t>(default(T));
        }
    }

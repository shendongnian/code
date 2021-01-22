    public static partial class StringExtensions
    {
        /// <summary>
        /// Converts the string to the specified type, using the default value configured for the type.
        /// </summary>
        /// <typeparam name="T">Type the string will be converted to. The type must implement IConvertable.</typeparam>
        /// <param name="original">The original string.</param>
        /// <returns>The converted value.</returns>
        public static T As<T>(this String original)
        {
            return As(original, CultureInfo.CurrentCulture,
                      default(T));
        }
    
        /// <summary>
        /// Converts the string to the specified type, using the default value configured for the type.
        /// </summary>
        /// <typeparam name="T">Type the string will be converted to.</typeparam>
        /// <param name="original">The original string.</param>
        /// <param name="defaultValue">The default value to use in case the original string is null or empty, or can't be converted.</param>
        /// <returns>The converted value.</returns>
        public static T As<T>(this String original, T defaultValue)
        {
            return As(original, CultureInfo.CurrentCulture, defaultValue);
        }
    
        /// <summary>
        /// Converts the string to the specified type, using the default value configured for the type.
        /// </summary>
        /// <typeparam name="T">Type the string will be converted to.</typeparam>
        /// <param name="original">The original string.</param>
        /// <param name="provider">Format provider used during the type conversion.</param>
        /// <returns>The converted value.</returns>
        public static T As<T>(this String original, IFormatProvider provider)
        {
            return As(original, provider, default(T));
        }
    
        /// <summary>
        /// Converts the string to the specified type.
        /// </summary>
        /// <typeparam name="T">Type the string will be converted to.</typeparam>
        /// <param name="original">The original string.</param>
        /// <param name="provider">Format provider used during the type conversion.</param>
        /// <param name="defaultValue">The default value to use in case the original string is null or empty, or can't be converted.</param>
        /// <returns>The converted value.</returns>
        /// <remarks>
        /// If an error occurs while converting the specified value to the requested type, the exception is caught and the default is returned. It is strongly recommended you
        /// do NOT use this method if it is important that conversion failures are not swallowed up.
        ///
        /// This method is intended to be used to convert string values to primatives, not for parsing, converting, or deserializing complex types.
        /// </remarks>
        public static T As<T>(this String original, IFormatProvider provider,
                              T defaultValue)
        {
            T result;
            Type type = typeof (T);
    
            if (String.IsNullOrEmpty(original)) result = defaultValue;
            else
            {
                // need to get the underlying type if T is Nullable<>.
    
                if (type.IsNullableType())
                {
                    type = Nullable.GetUnderlyingType(type);
                }
    
                try
                {
                    // ChangeType doesn't work properly on Enums
                    result = type.IsEnum
                                 ? (T) Enum.Parse(type, original, true)
                                 : (T) Convert.ChangeType(original, type, provider);
                }
                catch // HACK: what can we do to minimize or avoid raising exceptions as part of normal operation? custom string parsing (regex?) for well-known types? it would be best to know if you can convert to the desired type before you attempt to do so.
                {
                    result = defaultValue;
                }
            }
    
            return result;
        }
    }

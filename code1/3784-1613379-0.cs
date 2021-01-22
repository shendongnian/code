    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    namespace SomeNamespace
    {
        /// <summary>
        /// A parser for nullable types. Will return null when parsing fails.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        ///
        public static class NullableParser<T> where T : struct
        {
            public delegate bool TryParseDelegate(string s, out T result);
            /// <summary>
            /// A generic Nullable Parser. Supports parsing of all types that implements the tryParse method;
            /// </summary>
            /// <param name="text">Text to be parsed</param>
            /// <param name="result">Value is true for parse succeeded</param>
            /// <returns>bool</returns>
            public static bool TryParse(string s, out Nullable<T> result)
            {
                bool success = false;
                try
                {
                    if (string.IsNullOrEmpty(s))
                    {
                        result = null;
                        success = true;
                    }
                    else
                    {
                        IConvertible convertableString = s as IConvertible;
                        if (convertableString != null)
                        {
                            result = new Nullable<T>((T)convertableString.ToType(typeof(T),
                                CultureInfo.CurrentCulture));
                            success = true;
                        }
                        else
                        {
                            success = false;
                            result = null;
                        }
                    }
                }
                catch
                {
                    success = false;
                    result = null;
                }
                return success;
            }
        }
    }

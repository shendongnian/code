    using System;
    using System.Globalization;
    using System.Text;
    
    namespace System
    {
        /// <summary>
        ///     A formatter that will apply a format to a string of numeric values.
        /// </summary>
        /// <example>
        ///     The following example converts a string of numbers and inserts dashes between them.
        ///     <code>
        /// public class Example
        /// {
        ///      public static void Main()
        ///      {          
        ///          string stringValue = "123456789";
        ///  
        ///          Console.WriteLine(String.Format(new NumericStringFormatter(),
        ///                                          "{0} (formatted: {0:###-##-####})",stringValue));
        ///      }
        ///  }
        ///  //  The example displays the following output:
        ///  //      123456789 (formatted: 123-45-6789)
        ///  </code>
        /// </example>
        public class NumericStringFormatter : IFormatProvider, ICustomFormatter
        {
            /// <summary>
            ///     Converts the value of a specified object to an equivalent string representation using specified format and
            ///     culture-specific formatting information.
            /// </summary>
            /// <param name="format">A format string containing formatting specifications.</param>
            /// <param name="arg">An object to format.</param>
            /// <param name="formatProvider">An object that supplies format information about the current instance.</param>
            /// <returns>
            ///     The string representation of the value of <paramref name="arg" />, formatted as specified by
            ///     <paramref name="format" /> and <paramref name="formatProvider" />.
            /// </returns>
            /// <exception cref="System.NotImplementedException"></exception>
            public string Format(string format, object arg, IFormatProvider formatProvider)
            {
                var strArg = arg as string;
    
                //  If the arg is not a string then determine if it can be handled by another formatter
                if (strArg == null)
                {
                    try
                    {
                        return HandleOtherFormats(format, arg);
                    }
                    catch (FormatException e)
                    {
                        throw new FormatException(string.Format("The format of '{0}' is invalid.", format), e);
                    }
                }
    
                // If the format is not set then determine if it can be handled by another formatter
                if (string.IsNullOrEmpty(format))
                {
                    try
                    {
                        return HandleOtherFormats(format, arg);
                    }
                    catch (FormatException e)
                    {
                        throw new FormatException(string.Format("The format of '{0}' is invalid.", format), e);
                    }
                }
                var sb = new StringBuilder();
                var i = 0;
    
                foreach (var c in format)
                {
                    if (c == '#')
                    {
                        if (i < strArg.Length)
                        {
                            sb.Append(strArg[i]);
                        }
                        i++;
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
    
                return sb.ToString();
            }
    
            /// <summary>
            ///     Returns an object that provides formatting services for the specified type.
            /// </summary>
            /// <param name="formatType">An object that specifies the type of format object to return.</param>
            /// <returns>
            ///     An instance of the object specified by <paramref name="formatType" />, if the
            ///     <see cref="T:System.IFormatProvider" /> implementation can supply that type of object; otherwise, null.
            /// </returns>
            public object GetFormat(Type formatType)
            {
                // Determine whether custom formatting object is requested. 
                return formatType == typeof(ICustomFormatter) ? this : null;
            }
    
            private string HandleOtherFormats(string format, object arg)
            {
                if (arg is IFormattable)
                    return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
                else if (arg != null)
                    return arg.ToString();
                else
                    return string.Empty;
            }
        }
    }

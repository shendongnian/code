    /// <summary>
    /// Custom string formatter for TimeSpan that allows easy retrieval of Total segments.
    /// </summary>
    /// <example>
    /// TimeSpan myTimeSpan = new TimeSpan(27, 13, 5);
    /// string.Format("{0:th,###}h {0:mm}m {0:ss}s", myTimeSpan) -> "27h 13m 05s"
    /// string.Format("{0:TH}", myTimeSpan) -> "27.2180555555556"
    /// 
    /// NOTE: myTimeSpan.ToString("TH") does not work.  See Remarks.
    /// </example>
    /// <remarks>
    /// Due to a quirk of .NET Framework (up through version 4.5.1), 
    /// <code>TimeSpan.ToString(format, new TimeSpanFormatter())</code> will not work; it will always call 
    /// TimeSpanFormat.FormatCustomized() which takes a DateTimeFormatInfo rather than an 
    /// IFormatProvider/ICustomFormatter.  DateTimeFormatInfo, unfortunately, is a sealed class.
    /// </remarks>
    public class TimeSpanFormatter : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// Used to create a wrapper format string with the specified format.
        /// </summary>
        private const string DefaultFormat = "{{0:{0}}}";
        /// <remarks>
        /// IFormatProvider.GetFormat implementation. 
        /// </remarks>
        public object GetFormat(Type formatType)
        {
            // Determine whether custom formatting object is requested. 
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            return null;
        }
        /// <summary>
        /// Determines whether the specified format is looking for a total, and formats it accordingly.
        /// If not, returns the default format for the given <para>format</para> of a TimeSpan.
        /// </summary>
        /// <returns>
        /// The formatted string for the given TimeSpan.
        /// </returns>
        /// <remarks>
        /// ICustomFormatter.Format implementation.
        /// </remarks>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            // only apply our format if there is a format and if the argument is a TimeSpan
            if (string.IsNullOrWhiteSpace(format) ||
                formatProvider != this || // this should always be true, but just in case...
                !(arg is TimeSpan) ||
                arg == null)
            {
                // return the default for whatever our format and argument are
                return GetDefault(format, arg);
            }
            TimeSpan span = (TimeSpan)arg;
            string[] formatSegments = format.Split(new char[] { ',' }, 2);
            string tsFormat = formatSegments[0];
            // Get inner formatting which will be applied to the int or double value of the requested total.
            // Default number format is just to return the number plainly.
            string numberFormat = "{0}";
            if (formatSegments.Length > 1)
            {
                numberFormat = string.Format(DefaultFormat, formatSegments[1]);
            }
            // We only handle two-character formats, and only when those characters' capitalization match
            // (e.g. 'TH' and 'th', but not 'tH').  Feel free to change this to suit your needs.
            if (tsFormat.Length != 2 ||
                char.IsUpper(tsFormat[0]) != char.IsUpper(tsFormat[1]))
            {
                return GetDefault(format, arg);
            }
            // get the specified time segment from the TimeSpan as a double
            double valAsDouble;
            switch (char.ToLower(tsFormat[1]))
            {
                case 'd':
                    valAsDouble = span.TotalDays;
                    break;
                case 'h':
                    valAsDouble = span.TotalHours;
                    break;
                case 'm':
                    valAsDouble = span.TotalMinutes;
                    break;
                case 's':
                    valAsDouble = span.TotalSeconds;
                    break;
                case 'f':
                    valAsDouble = span.TotalMilliseconds;
                    break;
                default:
                    return GetDefault(format, arg);
            }
            // figure out if we want a double or an integer
            switch (tsFormat[0])
            {
                case 'T':
                    // format Total as double
                    return string.Format(numberFormat, valAsDouble);
                case 't':
                    // format Total as int (rounded down)
                    return string.Format(numberFormat, (int)valAsDouble);
                default:
                    return GetDefault(format, arg);
            }
        }
        /// <summary>
        /// Returns the formatted value when we don't know what to do with their specified format.
        /// </summary>
        private string GetDefault(string format, object arg)
        {
            return string.Format(string.Format(DefaultFormat, format), arg);
        }
    }

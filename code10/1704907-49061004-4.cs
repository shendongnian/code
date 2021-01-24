    using System.Globalization; // System.Globalization needed for IFormatProvider overload
    using System.Text; // System.Text required for StringBuilder class
    namespace Extensions
    {
        public static class DateTimeFormatExtension
        {
            // Consts for building the custom format string
            private const string ROUNDTRIP_FORMAT_PREFIX = "yyyy'-'MM'-'dd'T'HH':'mm':'ss";
            private const char ROUNDTRIP_FORMAT_FRACTION = 'f';
            private const char ROUNDTRIP_FORMAT_SUFFIX = 'K';
            // Appending the 'f' custom format string maxes out at "fffffff"(7 dp) and will throw an exception if given more 
            private const int DATETIME_MAX_DP = 7;
            private static int GetRoundtripLength(int decimalPlaces) =>
                ROUNDTRIP_FORMAT_PREFIX.Length + decimalPlaces + 2; // +2 to account for the '.' and the 'K' suffix
            public static string ToFormattedString(this DateTime input) => input.ToString();
            public static string ToFormattedString(this DateTime input, string format)
            {
                var provider = DateTimeFormatInfo.CurrentInfo;
                return input.ToFormattedString(format, provider);
            }
                        public static string ToFormattedString(this DateTime input, string format, IFormatProvider provider)
            {
                string parsedFormat = format;
                if (!string.IsNullOrWhiteSpace(format))
                {
                    switch (format[0])
                    {
                        case 'o':
                        case 'O':
                            var precision = format.Substring(1);
                            // Only do this if we have a custom 'o' string, otherwise us the base functionality
                            if (!string.IsNullOrWhiteSpace(precision))
                            {
                                // If the custom addition to the format string is an integer, use that to determine dp
                                if (int.TryParse(precision, out int decimalCount))
                                {
                                    // Build the format string
                                    var formatBuilder = new StringBuilder(GetRoundtripLength(decimalCount));
                                    formatBuilder.Append(ROUNDTRIP_FORMAT_PREFIX);
                                    // Append '.' and 'f' chars to format string (Append nothing if 0 dp)
                                    if (decimalCount > 0)
                                    {
                                        formatBuilder
                                            .Append('.')
                                            .Append(ROUNDTRIP_FORMAT_FRACTION,
                                                // Cap max dp length to avoid exceptions
                                                Math.Min(decimalCount, DATETIME_MAX_DP));
                                    }
                                    // Append 'K' suffix
                                    formatBuilder.Append(ROUNDTRIP_FORMAT_SUFFIX);
                                    parsedFormat = formatBuilder.ToString();
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
                return input.ToString(parsedFormat, provider);
            }
        }
    }

        /// <summary>
        ///     Implements a fast method to write a DateTime value to string, in the ISO "s" format.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        /// <devdoc>
        ///     This implementation exists just for performance reasons, it is semantically identical to
        ///     <code>
        /// text = value.HasValue ? value.Value.ToString("s") : string.Empty;
        /// </code>
        ///     However, it runs about 3 times as fast. (Measured using the VS2015 performace profiler)
        /// </devdoc>
        public static string ToIsoStringFast(DateTime? dateTime) {
            if (!dateTime.HasValue) {
                return string.Empty;
            }
            DateTime dt = dateTime.Value;
            char[] chars = new char[19];
            Write4Chars(chars, 0, dt.Year);
            chars[4] = '-';
            Write2Chars(chars, 5, dt.Month);
            chars[7] = '-';
            Write2Chars(chars, 8, dt.Day);
            chars[10] = 'T';
            Write2Chars(chars, 11, dt.Hour);
            chars[13] = ':';
            Write2Chars(chars, 14, dt.Minute);
            chars[16] = ':';
            Write2Chars(chars, 17, dt.Second);
            return new string(chars);
        }

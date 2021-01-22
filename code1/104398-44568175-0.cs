    // <summary>
        /// Returns a string containing a specified number of characters from the right side of a string.
        /// </summary>
        public static string Right(this string value, int length)
        {
            string result = value;
            if (value != null)
                result = value.Substring(0, Math.Min(value.Length, length));
            return result;
        }

    public static class StringExtensions
    {
        /// <summary>
        /// Converts a string to int.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <returns>The converted integer.</returns>
        public static int ParseToInt32(this string value)
        {
            return int.Parse(value);
        }
        /// <summary>
        /// Checks whether the value is integer.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <param name="result">The out int parameter.</param>
        /// <returns>true if the value is an integer; otherwise, false.</returns>
        public static bool TryParseToInt32(this string value, out int result)
        {
            return int.TryParse(value, out result);
        }
    }

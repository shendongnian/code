        /// <summary>
        /// Gets the last x-<paramref name="amount"/> of characters from the given string.
        /// If the given string's length is smaller than the requested <see cref="amount"/> the full string is returned.
        /// If the given <paramref name="amount"/> is negative, an empty string will be returned.
        /// </summary>
        /// <param name="string">The string from which to extract the last x-<paramref name="amount"/> of characters.</param>
        /// <param name="amount">The amount of characters to return.</param>
        /// <returns>The last x-<paramref name="amount"/> of characters from the given string.</returns>
        public static string GetLast(this string @string, int amount)
        {
            if (@string == null) {
                return @string;
            }
            if (amount < 0) {
                return String.Empty;
            }
            if (amount >= @string.Length) {
                return @string;
            } else {
                return @string.Substring(@string.Length - amount);
            }
        }

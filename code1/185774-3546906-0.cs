        /// <summary>
        /// Trim the front of a string and replace with "..." if it's longer than a certain length.
        /// </summary>
        /// <param name="value">String this extends.</param>
        /// <param name="maxLength">Maximum length.</param>
        /// <returns>Ellipsis shortened string.</returns>
        public static string TrimFrontIfLongerThan(this string value, int maxLength)
        {
            if (value.Length > maxLength)
            {
                return "..." + value.Substring(value.Length - (maxLength - 3));
            }
            return value;
        }

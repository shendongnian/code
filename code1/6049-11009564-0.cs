    public static class StringExtensions
    {
        /// <summary>
        /// FixedWidth string extension method.  Trims spaces, then pads right.
        /// </summary>
        /// <param name="self">extension method target</param>
        /// <param name="totalLength">The length of the string to return (including 'spaceOnRight')</param>
        /// <param name="spaceOnRight">The number of spaces required to the right of the content.</param>
        /// <returns>a new string</returns>
        /// <example>
        /// This example calls the extension method 3 times to construct a string with 3 fixed width fields of 20 characters, 
        /// 2 of which are reserved for empty spacing on the right side.
        /// <code>
        ///const int colWidth = 20;
        ///const int spaceRight = 2;
        ///string headerLine = string.Format(
        ///    "{0}{1}{2}",
        ///    "Title".FixedWidth(colWidth, spaceRight),
        ///    "Quantity".FixedWidth(colWidth, spaceRight),
        ///    "Total".FixedWidth(colWidth, spaceRight));
        /// </code>
        /// </example>
        public static string FixedWidth(this string self, int totalLength, int spaceOnRight)
        {
            if (totalLength < spaceOnRight) spaceOnRight = 1; // handle silly use.
            string s = self.Trim();
            if (s.Length > (totalLength - spaceOnRight))
            {
                s = s.Substring(0, totalLength - spaceOnRight);
            }
            return s.PadRight(totalLength);
        }
    }

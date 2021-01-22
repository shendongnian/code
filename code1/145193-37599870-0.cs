    /// <summary>
    /// Extensions to the Range class.
    /// </summary>
    public static class RangeExtensions
    {
        /// <summary>
        /// Returns the range as a string indicating its address.
        /// </summary>
        /// <param name="range">The range to convert to a string.</param>
        /// <returns>A string indicating the range's address.</returns>
        public static string ToAddressString(this Range range)
        {
            return range.Address[true, true, XlReferenceStyle.xlA1, false, null];
        }
    }

    public class ExcelUtil
    {
        /// <summary>
        /// Converts the given address string on the given sheet to a Range object.
        /// </summary>
        /// <param name="sheet">The worksheet.</param>
        /// <param name="addressString">The address string to convert.</param>
        /// <returns>The range.</returns>
        public static Range RangeFromAddresssString(Worksheet sheet, string addressString)
        {
            return sheet.Range[addressString];
        }
    }

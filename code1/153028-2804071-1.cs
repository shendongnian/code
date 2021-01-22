    /// <summary>
    /// Converts a byte array to a multi-row hex string containing 
    /// byte offset indices as a prefix for each row.
    /// </summary>
    /// <example>
    /// <![CDATA[
    /// 0000:   13 31 DC 81 95 2C 92 E5
    /// 0008:   CE 14 F6 C7 2E CA 8F 13
    /// 0010:   11 2E AB 80 2E 19 63 D1
    /// 0018:   0D D6 88 2D 95 BF 03 FE
    /// 0020:   6F 8F 2C 8A D8 A9 60 B4
    /// ]]>
    /// </example>
    [ValueConversion(typeof(byte[]), typeof(String))]
    public class ByteArrayToIndexedHexStringConverter : IValueConverter {
        /// <summary>
        /// Converts a byte array to a multi-row hex string.  
        /// Each row is prefixed with the starting byte offset and contains
        /// a fixed number of bytes.
        /// </summary>
        /// <param name="value">The byte array to convert.</param>
        /// <param name="targetType"></param>
        /// <param name="parameter">A string, parsable to an integer, indicating
        /// how many bytes per row.  Typically 8 or 16.</param>
        /// <param name="culture"></param>
        /// <returns>A string that looks similar to the HexEdit plugin for Notepad++.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null) return null;
            if (!(value is byte[])) {
                throw new ArgumentException("'value' must be a byte array.");
            }
            int numBytesPerRow;
            if ((parameter == null)
                || !(parameter is string)
                || !(int.TryParse((string)parameter, out numBytesPerRow))) {
                throw new ArgumentException("'parameter' must be a string parsable to an integer (numBytesPerRow).");
            }
            var hexSplit = BitConverter.ToString((byte[])value)
                .Replace('-', ' ')
                .Trim()
                .SplitIntoChunks(numBytesPerRow * 3)
                .ToList();
            int byteAddress = 0;
            var sb = new StringBuilder();
            for (int i = 0; i < hexSplit.Count; i++) {
                sb.AppendLine(byteAddress.ToString("X4") + ":\t" + hexSplit[i]);
                byteAddress += numBytesPerRow;
            }
            return sb.ToString();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
    }

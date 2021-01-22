    [ValueConversion(typeof(byte []), typeof(string))]
    public class ByteArrayConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            byte [] bytes = (byte [])value;
            StringBuilder sb = new StringBuilder(100);
            for (int x = 0; x<bytes.Length; x++)
            {
                sb.Append(bytes[x].ToString()).Append(" ");
            }
            return sb.ToString();
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
        #endregion
    }

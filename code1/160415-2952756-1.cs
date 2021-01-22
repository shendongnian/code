    public class ByteConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Byte b = (Byte)value;
            return "b" + b.ToString();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value as string;
            Byte result;
            if (Byte.TryParse(strValue, out result))
            {
                return result;
            }
            return DependencyProperty.UnsetValue;
        }
    }

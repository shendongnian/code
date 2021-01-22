    public class XAttributeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var xml = value as XElement;
            var name = parameter as string;
            return xml.Attribute(name).Value;
        }
    }

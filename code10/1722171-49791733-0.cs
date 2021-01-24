    public class XAttributesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var xe = value as XElement;
            if (xe == null)
                return Enumerable.Empty<XAttribute>();
            return xe.Attributes();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

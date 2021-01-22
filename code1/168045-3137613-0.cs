    public class JoinConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumerable = value as IEnumerable<string>;
            if (enumerable == null)
            {
                return DependencyProperty.UnsetValue;
            }
            else
            {
                return string.Join(Environment.NewLine, enumerable.ToArray());
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        }
    }

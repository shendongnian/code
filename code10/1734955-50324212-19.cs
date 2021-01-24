    /// <summary>This convert number to brush</summary>
    public class IsOddToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            // value is the integer input, we don't care about parameter or language
            // output should be type of Brush
            if (value is int && targetType == typeof(Brush))
            {
                bool isOdd = ((int)value) % 2 != 0;
                return isOdd ? Brushes.Gray : Brushes.DarkGray;
            }
            // if input (and output) is unknown
            return Brushes.Transparent;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            // We don't care about this
            throw new NotSupportedException();
        }
    }

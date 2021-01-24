    /// <summary>This convert number to brush</summary>
    public class IsoddToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            // value is the integer input, we don't care about parameter or language
            double? number = value as double; // all numbers in xaml is double
            // output should be type of SolidColorBrush
            if(number !=null && targetType == typeof(SolidColorBrush))
            {
                int numberInt = (int)number; // truncate as int
                bool isOdd = number.Value % 2 != 0;
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

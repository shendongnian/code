    [ValueConversion(typeof(double), typeof(double))]
    public class InvertDoubleConverter : IValueConverter
    {
        
        public object Convert(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo ci)
        {
            return -(double)value;
        }
        public object ConvertBack(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo ci)
        {
            return -(double)value;
        }
    }

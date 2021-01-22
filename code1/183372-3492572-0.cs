    [ValueConversion(typeof(double), typeof(double))]
    public class HeightAdjustmentConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double original = (double)value;
            return double - 60;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double adjusted = (double)value;
            return adjusted + 60;
        }
    }

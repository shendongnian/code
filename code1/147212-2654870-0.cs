    [ValueConversion(typeof(int), typeof(SolidColorBrush))]
    public class ColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int option = (int)value;
            switch(option)
            {
                default:
                    return Brushes.Black;
                case 1: 
                    return Brushes.Red;
                case 2: 
                    return Brushes.Green;
               // ...
            }
            
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // No need to convert back in this case
            throw new NotImplementedException();
        }
    }

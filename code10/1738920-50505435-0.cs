    public class ToWidthConverter : IValueConverter
    {
        object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double gridWidth = (double)value;
            return gridWidth * 2/6;
        }
        object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

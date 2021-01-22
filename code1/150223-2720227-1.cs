    public class TextBlockDataConveter:IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return "Error Message";
            }
            else
            {
                return value;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
    class TextBlockForegroundConverter:IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                SolidColorBrush brush = new SolidColorBrush();
                brush.Color = Colors.Red;
                return brush;
            }
            else
            {
                SolidColorBrush brush = new SolidColorBrush();
                brush.Color = Colors.Black;
                return brush;
 
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

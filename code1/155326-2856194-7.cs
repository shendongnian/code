    public class ColorConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((Color)value)
            {
                case Color.Red:
                    return Colors.Red;
                case Color.Blue:
                    return Colors.Blue;
                case Color.Green:
                    return Colors.Green;
                default:
                    throw new ArgumentOutOfRangeException("value");
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

    public class FalseToStringConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool && parameter is string)
            {
                if ((bool)value == false)
                    return parameter.ToString();
                else return null;
            }
            else
                throw new InvalidOperationException("The value must be a boolean and parameter must be a string");
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

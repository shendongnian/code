    public class ErrorIdColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(!(value is errorID))
                 throw new ArgumentException("value not of type errorID");
            errorID error = (errorID)value;
            if (error.HasFlag(errorID.SURNAME_DIFF))
            {
                return Brushes.Red;
            }
            ...
            return Brushes.Black;
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
       ....
    }

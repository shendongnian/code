    public class ErrorIdColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(!(value is errorID))
                 throw new ArgumentException("value not of type errorID");
            errorID error = (errorID)value;
            switch (error)
            {
                case errorID.SURNAME_DIFF:
                return Colors.Red;
               ...
            }
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
       ....
    }

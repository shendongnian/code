    public class StringToBoolConverter : IValueConverter
    {
        public object Convert(
               object value, 
               Type targetType, 
               object parameter, 
               CultureInfo culture)
        {
            return (string)value == "paid";
        }
        public object ConvertBack(
               object value, 
               Type targetType, 
               object parameter, 
               CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

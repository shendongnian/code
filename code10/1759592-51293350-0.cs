    public class DecimalPlace : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {           
            return (System.Convert.ToDouble(value) / 100.00).ToString();
        }    
    }

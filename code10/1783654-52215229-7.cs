    public class InverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                bool testValue = Convert.ToBoolean(value);
                return !testValue; // or do whatever you need with this boolean
            }
            catch { return true; } // or false
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                int testValue = Convert.ToInt32(!((bool)value));
                return testValue; // or do whatever you need with this boolean
            }
            catch { return 1; } 
        }
    }

    namespace WPFTestApplication
    {
        public class BoolToBackgroundColorConverter: IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value != null && !(bool)value)
                {
                    return new SolidColorBrush(Colors.Red);
                }
                else if(value != null && (bool)value && parameter != null)
                {
                    return (SolidColorBrush)parameter;
                }
                else
                {
                    return new SolidColorBrush(Colors.White);
                }
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }

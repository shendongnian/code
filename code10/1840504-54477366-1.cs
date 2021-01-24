        public class Myconverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                if ((bool)values[0])
                {
                    return (values[1] as FrameworkElement).Resources["ToggleButtonDanger"];
                }
                else
                    return (values[1] as FrameworkElement).Resources["ToggleButtonPrimary"];            
            }
    
           
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
           
        }

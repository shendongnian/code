    public class PropSelector : IMultiValueConverter  
    {  
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)  
        {  
            if (values != null)  
            {  
                return (values[0] as Item).GetPropertyValueAt(values[1]);  
            }  
            return "";  
        }  
  
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)  
        {  
            return null;  
        }  
    }  

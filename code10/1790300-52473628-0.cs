    public class MyDateConverter:IValueConverter  
    {  
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)  
        {  
            if (value is DateTime)
            {
                DateTime test = (DateTime) value;
                if (test.Year > 1900) // If year is greater than 1900 then display
                {
                    string date = test.ToString("d/M/yyyy"); // Your date format
                    return date;
                }
            }
            return string.Empty;
        }  
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)  
        {  
            throw new NotImplementedException();  
        }  
    }  

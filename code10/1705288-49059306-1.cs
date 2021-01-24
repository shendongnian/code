    using System;  
      
    namespace ValueConverters  
    {  
        class RactangleHeightConverters:IValueConverter  
        {  
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)  
            {  
                return value - 5;
            }  
      
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)  
            {  
               return null;
            }  
        }  
    }  

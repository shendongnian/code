      public class EnumToBoolConverter : IValueConverter
        {
            #region IValueConverter Members
    
            public object Convert(object value, 
                Type targetType, object parameter, 
                System.Globalization.CultureInfo culture) 
            { 
                if (parameter.Equals(value)) 
                    return true; 
                else 
                    return false; 
            } 
     
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) 
            { 
                return parameter; 
     
            } 
            #endregion 
    
        }  

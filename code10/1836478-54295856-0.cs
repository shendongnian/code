     public class OzViewConverter : IValueConverter
            {
    
                #region IValueConverter implementation
    
                public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                    var test = value as string; //here you can change the cast, depending on type object you are Binding 
                    if (!string.IsNullOrEmpty(test))  
                    {
                        return true;
                    }
                    return false;
                }
    
                public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                    throw new NotImplementedException ();
                }
    
                #endregion
            }

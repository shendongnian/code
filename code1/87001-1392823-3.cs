     public class BooleanWidthToConverter : IValueConverter {
            public object Convert(object value, Type targetType, 
                                  object parameter, CultureInfo culture){
                return ((bool) parameter)? value : 0;
            }
     
            public object ConvertBack(object value, Type targetType, 
                                      object parameter, CultureInfo culture){
                throw new NotImplementedException();
            }
        }

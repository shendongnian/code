    public class DebugConverter1 : IValueConverter
      {
        #region IValueConverter Members
    
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
           return value;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
          return value;
        }
    
        #endregion
      }
    {Binding Converter={StaticResource debugConverter1}}

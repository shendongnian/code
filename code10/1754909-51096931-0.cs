    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
    
               if ((bool)value)            
                   return Color.FromArgb(255, 0, 255, 0);
               else
                   return Color.FromArgb(255, 255, 0, 0);
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

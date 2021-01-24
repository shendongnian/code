    public class ImageConverter : IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {                        
            return "data:image;base64," + Convert.ToBase64String(value);;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo     culture)
        {
            throw new NotImplementedException();
        }
    
    }

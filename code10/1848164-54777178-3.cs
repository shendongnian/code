    public class ColorToSolidColorBrushValueConverter : IValueConverter 
    {
    
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;
    
            if (value is Color)
                return new SolidColorBrush((Color)value);
    
            throw new InvalidOperationException("Unsupported type [" + value.GetType().Name + "], ColorToSolidColorBrushValueConverter.Convert()");
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
       {
            throw new NotImplementedException();
        }
    }

    public class TextToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = (string)value;
            if (str == null) return new SolidColorBrush(Colors.Black);
            return str.StartsWith("<qs>") && str.EndsWith("<qe>") ? new SolidColorBrush(Colors.Red) :
                str.StartsWith("<as>") && str.EndsWith("<ae>") ? new SolidColorBrush(Colors.Green) :
                new SolidColorBrush(Colors.Black);
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

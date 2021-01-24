    public class NameToPathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imageName = value.ToString().Substring(3);
            return new BitmapImage(new Uri("pack://application:,,,/YourNamespace;component/Images/" + imageName + ".png"));
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

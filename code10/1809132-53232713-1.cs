    public class BooleanToImageConverter : IValueConverter
    {
        public object Convert(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            var uri = (bool)value
                ? "pack://application:,,,/ImgSrcIfTrue.png"
                : "pack://application:,,,/ImgSrcIfFalse.png";
            return new BitmapImage(new Uri(uri));
        }
        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

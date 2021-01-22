    public class FileToUIElementConverter :IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            FileStream fileStream = new FileStream((string)parameter, FileMode.Open); 
            return XamlReader.Load(fileStream) as DrawingImage;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

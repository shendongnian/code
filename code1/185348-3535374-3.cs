    <Image Source="{Binding Path=LanguageCode, Converter={StaticResource localizedImageSourceConverter}, ConverterParameter='Koala.jpg'}"/>
    public class LocalizedImageSourceConverter : IValueConverter
    {
        public object Convert(object values, Type targetType, object parameter, CultureInfo culture)
        {
            string fileName = Path.GetFileNameWithoutExtension((string)parameter);
            string extension = Path.GetExtension((string)parameter);
            string languageCode = (string)values;
            
            return string.Format("{0}{1}{2}", fileName, languageCode, extension);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

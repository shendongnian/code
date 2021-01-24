    public class MyResultImageConverter : IValueConverter  
    {
        public ImageSource OkImage { get; set; }
        public ImageSource FailImage { get; set; }
        public object Convert(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            var customObject = value as MyCustomObject;
            if (customObject == null)
            {
                return null;
            }
            return customObject.Code == MyEnum.OK ? OkImage : FailImage;
        }
        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

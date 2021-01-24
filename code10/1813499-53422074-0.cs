    public class TabToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {   
            string imageName;         
            switch (value.ToString())
            {
                case "1":
                    imageName= "logo-pp.png"
                    break;
                case "2":
                    imageName= "logo-pp2.png"
                    break;
                case "3":
                    imageName= "logo-pp3.png"
                    break;
                default:
                    imageName= "logo-pp.png"
                    break;
            }
            return ImageSource.FromResource($"Media.{imageName}", this.GetType().GetTypeInfo().Assembly);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

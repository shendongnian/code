    public class OrientationConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.UWP:
                        return StackOrientation.Horizontal;
                    case Device.iOS:
                        return StackOrientation.Vertical;
                    default: return StackOrientation.Horizontal;
                }
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

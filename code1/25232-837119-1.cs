    public class MyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string strVal = value as string;
            switch (strVal)
            {
                case "2":
                    Rectangle rect = new Rectangle();
                    rect.Fill = Brushes.Red;
                    return rect;
    
                default:
                    Image img = new Image();
                    ImageSourceConverter s = new ImageSourceConverter();
                    img.Source = (ImageSource)s.ConvertFromString("MyImage.png");
                    return img;
            }
        }
    }

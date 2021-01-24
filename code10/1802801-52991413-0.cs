    public class ValueToImageBrush : IValueConverter
    {
        private const string _filePath = "pack://application:,,,/XXX;component/brush.png";
        private BitmapImage _baseImage;
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var doubleValue = value as double?;
            if (doubleValue == null) return new SolidColorBrush(Colors.LightSlateGray);
                    
            var baseImg = LoadImage();           
            var img = CutImage(baseImg, doubleValue.Value);
            
            return InitImageBrush(img);
        }       
        
        private BitmapImage LoadImage()
        {
            if (_baseImage == null)
            {
                _baseImage = new BitmapImage();
                _baseImage.BeginInit();
                _baseImage.UriSource = new Uri(_filePath);
                _baseImage.EndInit();
            }
            return _baseImage;
        }
        private static ImageSource CutImage(BitmapImage baseImg, double doubleValue)
        {
            var img = baseImg as ImageSource;
            if (doubleValue < 50)
            {
                var usedHight = Math.Max(25.0, baseImg.PixelHeight * (doubleValue * 2 / 100));
                img = new CroppedBitmap(baseImg,
                    new Int32Rect(baseImg.PixelWidth / 2, 0, baseImg.PixelWidth / 2, (int)usedHight));
            }
            else if (doubleValue < 75)
            {
                var usedWidth = baseImg.PixelWidth * (doubleValue / 100);
                img = new CroppedBitmap(baseImg, new Int32Rect(200 - (int)usedWidth, 0, (int)usedWidth, baseImg.PixelHeight));
            }
            return img;
        }
        private static object InitImageBrush(ImageSource img)
        {
            ImageBrush imgBrush = new ImageBrush();
            imgBrush.ImageSource = img;
            imgBrush.Stretch = Stretch.None;
            return imgBrush;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

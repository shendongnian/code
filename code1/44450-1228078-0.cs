        [ValueConversion(typeof(string), typeof(BitmapImage))]
    public class PathToBitmapImage : IValueConverter
    {
        public static BitmapImage ConvertToImage(string path)
        {
            if (!File.Exists(path))
                return null;
            BitmapImage bitmapImage = null;
            try
            {
                bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = new FileStream(path, FileMode.Open, FileAccess.Read);
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.StreamSource.Dispose();
            }
            catch (IOException ioex)
            {
            }
            return bitmapImage;
        }
        #region IValueConverter Members
        public virtual object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || !(value is string))
                return null;
            var path = value as string;
            return ConvertToImage(path);
        }
        public virtual object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

    public class PreLoadImageConverter : IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
        if (value == null) return null;
        string imagePath = value.ToString();
    
        ImageSource imageSource;
        using (var stream = new MemoryStream())
        {
          Bitmap bitmap = new Bitmap(imagePath);
          bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);   
          PngBitmapDecoder bitmapDecoder = new PngBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
          imageSource = bitmapDecoder.Frames[0];
          imageSource.Freeze();
        }
        return imageSource;
      }
    
      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
        throw new Exception("The method or operation is not implemented.");
      }
    }

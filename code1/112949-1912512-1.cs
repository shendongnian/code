    [ValueConversion(typeof(String), typeof(BitmapSource))]
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte[] val = new byte[((string)value).Length];
            for (int i = 0; i < val.Length; i++)
            {
                val[i] = (byte)((string)value)[i];
            }
            MemoryStream ms = new MemoryStream(val);
            
            BitmapSource source = null;
            JpegBitmapDecoder decoder = new JpegBitmapDecoder(ms, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
            if (decoder.Frames != null && decoder.Frames.Count > 0)
                source = decoder.Frames[0];
            return source;
        }
    }

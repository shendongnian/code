       public class ByteToImageConverter : IValueConverter
            {
                public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                    if(string.IsNullOrEmpty(value.ToString())return;
                    var imgBytes = Convert.FromBase64String(value.ToString());
                    if (imgBytes == null)
                        return null;
                    using (var stream = new MemoryStream(imgBytes))
                    {
                        return BitmapFrame.Create(stream,
                            BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                    }
                }
        
                public object ConvertBack(object value, Type targetType, object parameter,
                    System.Globalization.CultureInfo culture)
                {
                    throw new NotImplementedException();
                }
            }

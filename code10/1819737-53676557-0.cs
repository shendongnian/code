    public object Convert(object value, Type targetType, object parameter, string language)
        {
            string imageFolderPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Images");
            var path = (Uri)value;
            SKBitmap map;
            using (FileStream stream = new FileStream(imageFolderPath + "\\" + path.Segments[3],
                System.IO.FileMode.Open, FileAccess.Read))
            {
                map = SKBitmap.Decode(stream);
            }
            return map.ToWriteableBitmap();
        }

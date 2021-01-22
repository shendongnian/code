       internal static ImageSource ToImageSource(this byte[] iconBytes)
        {
            if (iconBytes == null)
                throw new ArgumentNullException(nameof(iconBytes));
            using (var ms = new MemoryStream(iconBytes))
            {
                return BitmapFrame.Create(ms, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
            }
        }

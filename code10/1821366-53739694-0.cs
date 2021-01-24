        /// <summary>
        /// Convert byte[] to bitmapimage
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static BitmapImage byteArrayToImage(byte[] array)
        {
            if (array != null)
            {
                using (var ms = new MemoryStream(array))
                {
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = ms;
                    image.EndInit();
                    return image;
                }
            }
            return null;
        }

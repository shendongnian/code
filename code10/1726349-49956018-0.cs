    ///<summary>
        /// Converts an System.Drawing.Image to an BitmapImage
        ///</summary>
        ///<param name="image">System.Drawing.Image</param>
        ///<param name="disposeImage">Image dispose</param>
        ///<param name="format">ImageFormat</param>
        ///<returns>BitmapImage or null</returns>
        public static BitmapImage ImageToBitmapImage(Image image, bool disposeImage = true, ImageFormat format = null)
        {
            if (image != null)
            {
                if (format == null)
                {
                    format = ImageFormat.Tiff;
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    BitmapImage bmi = new BitmapImage();
                    bmi.BeginInit();
                    image.Save(ms, format);
                    bmi.StreamSource = new MemoryStream(ms.ToArray());
                    bmi.EndInit();
                    bmi.Freeze();
                    if (disposeImage)
                    {
                        image.Dispose();
                    }
                    return bmi;
                }
            }
            return null;
        }

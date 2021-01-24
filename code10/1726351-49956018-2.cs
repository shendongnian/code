    ///<summary>
        /// Converts an System.Drawing.Image to an BitmapImage
        ///</summary>
        ///<param name="image">System.Drawing.Image</param>
        ///<param name="filePath">Physical path (C:\someimg.bmp)</param>
        ///<param name="disposeImage">Image dispose</param>
        ///<param name="format">ImageFormat</param>
        ///<returns>bool</returns>
        public static bool ImageToFile(Image image, string filePath, bool disposeImage = true, ImageFormat format = null)
        {
            if (image != null)
            {
                if (format == null)
                {
                    format = ImageFormat.Tiff;
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write))
                    {
                        image.Save(ms, format);
                        ms.Position = 0;
                        ms.CopyTo(fs);
                    }
                    if (disposeImage)
                    {
                        image.Dispose();
                    }
                }
                if (File.Exists(filePath))
                {
                    return true;
                }
            }
            return false;
        }

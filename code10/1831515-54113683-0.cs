    #region IconToBitmapImage
        ///<summary>
        /// Converts an <see cref="Icon"/> to an <see cref="BitmapImage"/>
        ///</summary>
        ///<param name="icon">Icon source</param>
        ///<param name="format">ImageFormat</param>
        ///<param name="disposeIcon">Icon dispose</param>
        ///<returns><see cref="BitmapImage"/> or <see cref="T:null"/></returns>
        public static BitmapImage IconToBitmapImage(Icon icon, ImageFormat format = null, bool disposeIcon = true)
        {
            if (icon != null)
            {
                using (Bitmap bm = icon.ToBitmap())
                {
                    MemoryStream ms = new MemoryStream();
                    bm.MakeTransparent(Color.Transparent); // define the background as transparent
                    bm.Save(ms, format ?? ImageFormat.Tiff);
                    ms.Position = 0;
                    BitmapImage bmi = new BitmapImage();
                    bmi.BeginInit();
                    bmi.StreamSource = ms;
                    bmi.EndInit();
                    bmi.Freeze();
                    if (disposeIcon)
                    {
                        icon.Dispose();
                    }
                    return bmi;
                }
            }
            return null;
        }
        #endregion

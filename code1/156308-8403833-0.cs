        /// <summary>
        /// Scale Image By A Percentage - Scale Factor between 0 and 1.
        /// </summary>
        /// <param name="originalImg">Image: Image to scale</param>
        /// <param name="ZoomFactor">Float: Sclae Value - 0 to 1 are the usual values</param>
        /// <returns>Image: Scaled Image</returns>
        public static Image ScaleByPercent(Image originalImg, float ZoomFactor)
        {    
            int destWidth = (int)((float)originalImg.Width * ZoomFactor);
            int destHeight = (int)((float)originalImg.Height * ZoomFactor);
            Bitmap bmPhoto = new Bitmap(destWidth, destHeight, GetNonIndexedPixelFormat(originalImg)); // PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(originalImg.HorizontalResolution,  originalImg.VerticalResolution);
            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grPhoto.DrawImage(originalImg,
                new Rectangle(0, 0, destWidth, destHeight),
                new Rectangle(0, 0, originalImg.Width, originalImg.Height),
                GraphicsUnit.Pixel);
            grPhoto.Dispose();
            return bmPhoto;
        }
        /// <summary>
        /// Gets the closest non-indexed pixel format
        /// </summary>
        /// <param name="originalImage">Image: Original image</param>
        /// <returns>PixelFormat: Closest non-pixel image format</returns>
        public static PixelFormat GetNonIndexedPixelFormat(Image originalImage)
        {
            /*
             * These formats cause an error when creating a GDI Graphics Oblect, so must be converted to non Indexed
             * Error is "A graphics object cannot be created from an image that has an indexed pixel format"
             * 
                PixelFormat.Undefined 
                PixelFormat.DontCare 
                PixelFormat.1bppIndexed
                PixelFormat.4bppIndexed
                PixelFormat.8bppIndexed
                PixelFormat.16bppGrayScale
                PixelFormat.16bppARGB1555
             * 
             * An attempt is made to use the closest (i.e. smallest fitting) format that will hold the palette.
             */
            switch (originalImage.PixelFormat)
            {
                case PixelFormat.Undefined: 
                    //This is also the same Enumation as PixelFormat.DontCare:
                    return PixelFormat.Format24bppRgb;
                case PixelFormat.Format1bppIndexed:
                    return PixelFormat.Format16bppRgb555;
                case PixelFormat.Format4bppIndexed:
                    return PixelFormat.Format16bppRgb555;
                case PixelFormat.Format8bppIndexed:
                    return PixelFormat.Format16bppRgb555;
                case PixelFormat.Format16bppGrayScale:
                    return PixelFormat.Format16bppArgb1555;
                case PixelFormat.Format32bppArgb:
                    return PixelFormat.Format24bppRgb;                
                default:
                    return originalImage.PixelFormat;
            }
        }
        /// <summary>
        /// Resize image keeping aspect ratio.
        /// </summary>
        /// <param name="originalImg">Image: Image to scale</param>
        /// <param name="Width">Int: Required width in pixels</param>
        /// <param name="Height">Int: Required height in pixels</param>
        /// <param name="BackgroundColour">Color: Background colour</param>
        /// <returns>Image: Scaled Image</returns>
        public static Image Resize(Image originalImg, int Width, int Height, Color BackgroundColour)
        {
            int destX = 0;
            int destY = 0;
            float nPercent = 0f;
            float nPercentW = ((float)Width / (float)originalImg.Width);
            float nPercentH = ((float)Height / (float)originalImg.Height);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16(((float)Width - ((float)originalImg.Width * nPercent)) / 2f);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16(((float)Height - ((float)originalImg.Height * nPercent)) / 2f);
            }
            int destWidth = (int)(originalImg.Width * nPercent);
            int destHeight = (int)(originalImg.Height * nPercent);
            Bitmap bmPhoto = new Bitmap(Width, Height, GetNonIndexedPixelFormat(originalImg)); // PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(originalImg.HorizontalResolution, originalImg.VerticalResolution);
            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(BackgroundColour);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grPhoto.DrawImage(originalImg,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(0, 0, originalImg.Width, originalImg.Height), GraphicsUnit.Pixel);
            grPhoto.Dispose();
            return bmPhoto;
        }

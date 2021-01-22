        /// <summary>
        /// Retrieves the Encoder Information for a given MimeType
        /// </summary>
        /// <param name="mimeType">String: Mimetype</param>
        /// <returns>ImageCodecInfo: Mime info or null if not found</returns>
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            var encoders = ImageCodecInfo.GetImageEncoders();
            return encoders.FirstOrDefault( t => t.MimeType == mimeType );
        }
    
        /// <summary>
        /// Save an Image as a JPeg with a given compression
        ///  Note: Filename suffix will not affect mime type which will be Jpeg.
        /// </summary>
        /// <param name="image">Image: Image to save</param>
        /// <param name="fileName">String: File name to save the image as. Note: suffix will not affect mime type which will be Jpeg.</param>
        /// <param name="compression">Long: Value between 0 and 100.</param>
        private static void SaveJpegWithCompressionSetting(Image image, string fileName, long compression)
        {
            var eps = new EncoderParameters(1);
            eps.Param[0] = new EncoderParameter(Encoder.Quality, compression);
            var ici = GetEncoderInfo("image/jpeg");
            image.Save(fileName, ici, eps);
        }
    
        /// <summary>
        /// Save an Image as a JPeg with a given compression
        /// Note: Filename suffix will not affect mime type which will be Jpeg.
        /// </summary>
        /// <param name="image">Image: This image</param>
        /// <param name="fileName">String: File name to save the image as. Note: suffix will not affect mime type which will be Jpeg.</param>
        /// <param name="compression">Long: Value between 0 and 100.</param>
        public static void SaveJpegWithCompression(this Image image, string fileName, long compression)
        {
            SaveJpegWithCompressionSetting( image, fileName, compression );
        }

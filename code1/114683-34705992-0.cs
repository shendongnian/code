    namespace YourApp
    {
        #region Namespaces
        using System;
        using System.Drawing;
        using System.Drawing.Imaging;
        using System.Drawing.Drawing2D;
        #endregion
    
        /// <summary>Generic helper functions related to graphics.</summary>
        public static class ImageExtensions
        {
            /// <summary>Resizes an image to a new width and height value.</summary>
            /// <param name="image">The image to resize.</param>
            /// <param name="newWidth">The width of the new image.</param>
            /// <param name="newHeight">The height of the new image.</param>
            /// <param name="mode">Interpolation mode.</param>
            /// <param name="maintainAspectRatio">If true, the image is centered in the middle of the returned image, maintaining the aspect ratio of the original image.</param>
            /// <returns>The new image. The old image is unaffected.</returns>
            public static Image ResizeImage(this Image image, int newWidth, int newHeight, InterpolationMode mode = InterpolationMode.Default, bool maintainAspectRatio = false)
            {
                Bitmap output = new Bitmap(newWidth, newHeight, image.PixelFormat);
    
                using (Graphics gfx = Graphics.FromImage(output))
                {
                    gfx.Clear(Color.FromArgb(0, 0, 0, 0));
                    gfx.InterpolationMode = mode;
                    if (mode == InterpolationMode.NearestNeighbor)
                    {
                        gfx.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        gfx.SmoothingMode = SmoothingMode.HighQuality;
                    }
    
                    double ratioW = (double)newWidth / (double)image.Width;
                    double ratioH = (double)newHeight / (double)image.Height;
                    double ratio = ratioW < ratioH ? ratioW : ratioH;
                    int insideWidth = (int)(image.Width * ratio);
                    int insideHeight = (int)(image.Height * ratio);
    
                    gfx.DrawImage(image, new Rectangle((newWidth / 2) - (insideWidth / 2), (newHeight / 2) - (insideHeight / 2), insideWidth, insideHeight));
                }
    
                return output;
            }
    	}
    }

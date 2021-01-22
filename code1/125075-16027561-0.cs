      /// <summary>
      /// Method to rotate a Bitmap image. The result can be one of three cases:
      /// - upsizeOk = true: output image will be larger than the input, and no clipping occurs 
      /// - upsizeOk = false & clipOk = true: output same size as input, clipping occurs
      /// - upsizeOk = false & clipOk = false: output same size as input, image reduced, no clipping
      /// 
      /// A background color must be specified, and this color will fill the edges that are not 
      /// occupied by the rotated image. If color = transparent the output image will be 32-bit, 
      /// otherwise the output image will be 24-bit.
      /// 
      /// Note that this method always returns a new Bitmap object, even if rotation is zero - in 
      /// which case the returned object is a clone of the input object. 
      /// </summary>
      /// <param name="inputImage">input Bitmap object, is not modified</param>
      /// <param name="angleDegrees">angle of rotation, in degrees</param>
      /// <param name="upsizeOk">see comments above</param>
      /// <param name="clipOk">see comments above, not used if upsizeOk = true</param>
      /// <param name="backgroundColor">color to fill exposed parts of the background</param>
      /// <returns>new Bitmap object, may be larger than input image</returns>
      public static Bitmap RotateImage(Image inputImage, float angleDegrees, bool upsizeOk, 
                                       bool clipOk, Color backgroundColor)
      {
         // Test for zero rotation and return a clone of the input image
         if (angleDegrees == 0f)
            return (Bitmap)inputImage.Clone();
         // Set up old and new image dimensions, assuming upsizing not wanted and clipping OK
         int oldWidth = inputImage.Width;
         int oldHeight = inputImage.Height;
         int newWidth = oldWidth;
         int newHeight = oldHeight;
         float scaleFactor = 1f;
         // If upsizing wanted or clipping not OK calculate the size of the resulting bitmap
         if (upsizeOk || !clipOk)
         {
            double angleRadians = angleDegrees * Math.PI / 180d;
            double cos = Math.Abs(Math.Cos(angleRadians));
            double sin = Math.Abs(Math.Sin(angleRadians));
            newWidth = (int)Math.Round(oldWidth * cos + oldHeight * sin);
            newHeight = (int)Math.Round(oldWidth * sin + oldHeight * cos);
         }
         // If upsizing not wanted and clipping not OK need a scaling factor
         if (!upsizeOk && !clipOk)
         {
            scaleFactor = Math.Min((float)oldWidth / newWidth, (float)oldHeight / newHeight);
            newWidth = oldWidth;
            newHeight = oldHeight;
         }
         // Create the new bitmap object. If background color is transparent it must be 32-bit, 
         //  otherwise 24-bit is good enough.
         Bitmap newBitmap = new Bitmap(newWidth, newHeight, backgroundColor == Color.Transparent ? 
                                          PixelFormat.Format32bppArgb : PixelFormat.Format24bppRgb);
         newBitmap.SetResolution(inputImage.HorizontalResolution, inputImage.VerticalResolution);
         // Create the Graphics object that does the work
         using (Graphics graphicsObject = Graphics.FromImage(newBitmap))
         {
            graphicsObject.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphicsObject.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphicsObject.SmoothingMode = SmoothingMode.HighQuality;
            // Fill in the specified background color if necessary
            if (backgroundColor != Color.Transparent)
               graphicsObject.Clear(backgroundColor);
            // Set up the built-in transformation matrix to do the rotation and maybe scaling
            graphicsObject.TranslateTransform(newWidth / 2f, newHeight / 2f);
            if (scaleFactor != 1f)
               graphicsObject.ScaleTransform(scaleFactor, scaleFactor);
            graphicsObject.RotateTransform(angleDegrees);
            graphicsObject.TranslateTransform(-oldWidth / 2f, -oldHeight / 2f);
            // Draw the result 
            graphicsObject.DrawImage(inputImage, 0, 0);
         }
         return newBitmap;
      }

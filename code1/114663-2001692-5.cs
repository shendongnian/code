    private void resizeImage(string path, string originalFilename, 
                         /* note changed names */
                         int canvasWidth, int canvasHeight)
    {
        Image image = Image.FromFile(path + originalFilename);
        int originalHeight = image.Height;
        int originalWidth = image.Width;
        System.Drawing.Image thumbnail = 
            new Bitmap(canvasWidth, canvasHeight); // changed parm names
        System.Drawing.Graphics graphic = 
                     System.Drawing.Graphics.FromImage(thumbnail);
        graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
        graphic.SmoothingMode = SmoothingMode.HighQuality;
        graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
        graphic.CompositingQuality = CompositingQuality.HighQuality;
        /* ------------------ new code --------------- */
        // Figure out the ratio
        double ratioX = (double) canvasWidth / (double) originalWidth;
        double ratioY = (double) canvasHeight / (double) originalHeight;
        // use whichever multiplier is smaller
        double ratio = ratioX < ratioY ? ratioX : ratioY;
        // now we can get the new height and width
        int newHeight = Convert.ToInt32(originalHeight * ratio);
        int newWidth = Convert.ToInt32(originalWidth * ratio);
        // Now calculate the X,Y position of the upper-left corner 
        // (one of these will always be zero)
        int posX = Convert.ToInt32((canvasWidth - (originalWidth * ratio)) / 2);
        int posY = Convert.ToInt32((canvasHeight - (originalHeight * ratio)) / 2);
        graphic.Clear(Color.White); // white padding
        graphic.DrawImage(image, posX, posY, newWidth, newHeight);
        /* ------------- end new code ---------------- */
        System.Drawing.Imaging.ImageCodecInfo[] info =
                         ImageCodecInfo.GetImageEncoders();
        EncoderParameters encoderParameters;
        encoderParameters = new EncoderParameters(1);
        encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality,
                         100L);            
        thumbnail.Save(path + width + "." + originalFilename, info[1], 
                         encoderParameters);
    }

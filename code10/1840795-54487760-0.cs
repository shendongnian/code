    /// <summary>
    /// Apply scaling (if enabled) to the given image 
    /// </summary>
    /// <param name="imageToScale">Scale image down by x.</param>
    /// <param name="watchmanData">Watchman data containing settings.</param>
    /// <returns>The original image, or a scaled down one.</returns>
    public static Bitmap ApplyScaling(Bitmap imageToScale, Setting watchmanData)
    {
        var returnData = imageToScale;
    
        if (watchmanData.ActuallyScaleDown)
        {
            using (var inStream = new MemoryStream())
            {
                imageToScale.Save(inStream, ImageFormat.Bmp);
    
                inStream.Position = 0;  //--> not sure you need this...maybe
    
                var outStream = new MemoryStream();
    
                MagicImageProcessor.ProcessImage(inStream, outStream,
                    new ProcessImageSettings {
                       Width = imageToScale.Width / watchmanData.ScaleBy});
    
                returnData = (Bitmap)Image.FromStream(outStream);
            }
        }
    
        return returnData;
    }

    if (resized.PixelFormat != PixelFormat.Format1bppIndexed)
    {
        using (Bitmap bmp = convertToBitonal(resized))
            bmp.Save(outputFilename, System.Drawing.Imaging.ImageFormat.Png);
    }
    else
    {
        resized.Save(outputFilename, System.Drawing.Imaging.ImageFormat.Png);
    }

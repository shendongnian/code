    var output = new Bitmap(outputWidth, outputHeight);
    var outputGraphics = Graphics.FromImage(output);
    
    outputGraphics.DrawImage(sourceBitmap, destRect, srcRect, GraphicsUnit.Pixel);
    
    using (var fs = File.OpenWrite(outputFilePath))
    {
    	output.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
    }

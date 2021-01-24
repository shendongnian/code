    using (var img = new MagickImage(inputStream))
    {
        img.AutoOrient();   // Fix orientation
        img.Write(outputPath);
    }

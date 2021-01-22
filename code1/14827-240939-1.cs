    System.Drawing.Image SourceImage = System.Drawing.Image.FromFile("the.gif");
    System.Drawing.Bitmap NewImage = new System.Drawing.Bitmap(SourceImage);
    // Do Processing
    NewImage.MakeTransparent();
    // Store changes
    NewImage.Save(..., System.Drawing.Imaging.ImageFormat.Png);

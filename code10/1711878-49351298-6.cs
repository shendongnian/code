    List<string> lFiles = new List<string>();
    lFiles.Add(@"C:\Users\David\Pictures\1.jpg");
    lFiles.Add(@"C:\Users\David\Pictures\2.jpg");
    lFiles.Add(@"C:\Users\David\Pictures\3.jpg");
    lFiles.Add(@"C:\Users\David\Pictures\4.jpg");
    lFiles.Add(@"C:\Users\David\Pictures\5.jpg");
    using (MagickImageCollection images = new MagickImageCollection())
    {
        foreach (string tempFile in lFiles)
        {
            images.Add(tempFile);
        }
        using (var mask = new MagickImage("xc:black", 100, 100))
        {
            mask.Settings.FillColor = MagickColors.White;
            mask.Draw(new DrawableCircle(50, 50, 50, 88));
            mask.HasAlpha = false;
            foreach (var image in images)
            {
                image.Resize(100, 100);
                image.Composite(mask, CompositeOperator.CopyAlpha);
            }
        }
        using (var shadow = new MagickImage("xc:none", 100, 100))
        {
            shadow.Settings.FillColor = MagickColors.Black;
            shadow.Draw(new DrawableCircle(50, 50, 50, 90));
            shadow.Blur(0, 5);
            foreach (var image in images)
            {
                image.Composite(shadow, CompositeOperator.DstOver);
            }
        }
        images.First().BackgroundColor = MagickColors.None;
        using (IMagickImage result = images.SmushHorizontal(-25))
        {
            result.Write(@"C:\Users\David\Pictures\combinedImgs.png");
        }
    }

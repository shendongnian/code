    ImageSource imageSource;
    
    Icon icon = Icon.ExtractAssociatedIcon(path);
    
    using (Bitmap bmp = icon.ToBitmap())
    {
       var stream = new MemoryStream();
       bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
       imageSource = BitmapFrame.Create(stream);
    }

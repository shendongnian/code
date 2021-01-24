    public static Bitmap ResizeImage(Bitmap source, Size size)
    {
       var scale = Math.Min(size.Width / (float)source.Width, size.Height / (float)source.Height);
    
       var bmp = new Bitmap(size.Width, size.Height);
    
       using (var graph = Graphics.FromImage(bmp))
       {
          graph.InterpolationMode = InterpolationMode.High;
          graph.CompositingQuality = CompositingQuality.HighQuality;
          graph.SmoothingMode = SmoothingMode.AntiAlias;
    
          var scaleWidth = source.Width * scale;
          var scaleHeight = source.Height * scale;
    
          graph.DrawImage(source, (size.Width - scaleWidth) / 2, (source.Height - scaleHeight) / 2, scaleWidth, scaleHeight);
       }
       return bmp;
    }

    public static Bitmap ResizeImage(Bitmap source, Size size)
    {
       var scale = Math.Min(size.Width / (double)source.Width, size.Height / (double)source.Height);   
       var bmp = new Bitmap((int)(source.Width * scale), (int)(source.Height * scale));
    
       using (var graph = Graphics.FromImage(bmp))
       {
          graph.InterpolationMode = InterpolationMode.High;
          graph.CompositingQuality = CompositingQuality.HighQuality;
          graph.SmoothingMode = SmoothingMode.AntiAlias;
          graph.DrawImage(source, 0, 0, bmp.Width, bmp.Height);
       }
       return bmp;
    }

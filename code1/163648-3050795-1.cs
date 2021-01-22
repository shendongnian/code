    Size iconSize = SystemInformation.SmallIconSize;
    Bitmap bitmap = new Bitmap(iconSize.Width, iconSize.Height);
    
    using (Graphics g = Graphics.FromImage(bitmap))   
    {
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        g.DrawImage(SystemIcons.Error.ToBitmap(), new Rectangle(Point.Empty, iconSize));   
    }
    
    Icon smallerErrorIcon = Icon.FromHandle(bitmap.GetHicon());

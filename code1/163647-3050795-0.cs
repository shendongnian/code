    using (Graphics g = Graphics.FromImage(bitmap))   
    {
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        g.DrawIcon(SystemIcons.Error, new Rectangle(Point.Empty, iconSize));   
    }

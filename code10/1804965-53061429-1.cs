    using (GraphicsPath path = new GraphicsPath())
    {
        path.AddString(
            text,                         
            _fontStyle.FontFamily,      
            (int)_fontStyle.Style,      
            e.Graphics.DpiY * fontSize / 72f,       // em size
            new Point(0, 0),                       // location where to draw text
            string_format);          
    
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
        e.Graphics.CompositingMode = CompositingMode.SourceOver;
        e.Graphics.DrawPath(new Pen(Color.Red), path);
    }

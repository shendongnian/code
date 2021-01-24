    private void Canvas_Paint(object sender, PaintEventArgs e)
    {
        using (GraphicsPath path = new GraphicsPath())
        using (StringFormat format = new StringFormat(StringFormatFlags.NoClip | StringFormatFlags.NoWrap))
        {
            format.Alignment = [StringAlignment.Center/Near/Far]; //As selected
            format.LineAlignment = [StringAlignment.Center/Near/Far]; //As selected
            path.AddString(fontObject.Text, fontObject.FontFamily, (int)fontObject.FontStyle, fontObject.SizeInEms, Canvas.ClientRectangle, format);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.CompositingMode = CompositingMode.SourceOver;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            if (fontObject.Outlined) { 
                e.Graphics.DrawPath(fontObject.Outline, path);
            }
            using(SolidBrush brush = new SolidBrush(fontObject.FillColor)) {
                e.Graphics.FillPath(brush, path);
            }
        }
    }

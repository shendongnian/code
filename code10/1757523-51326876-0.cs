    private string zoneName = "Name from Constructor";
    public override void OnRender(Graphics g)
    {
        base.OnRender(g);
        
        // Measure the size of the text. 
        // You might want to add some extra space around your text. 
        // MeasureString is quite tricky...
        SizeF textSize = g.MeasureString(this.zoneName, SystemFonts.DefaultFont);
        
        // Get LocalPoint (your LatLng coordinate in pixel)
        Point localPosition = this.LocalPosition;
        // Move the localPosition by the half size of the text.
        PointF textPosition = new PointF((float)(localPosition.X - textSize.Width / 2f),(float)(localPosition.Y - textSize.Height / 2f));
        // Draw Background
        g.FillRectangle(SystemBrushes.Control, new RectangleF(textPosition, textSize));
        g.DrawString(this.zoneName, SystemFonts.DefaultFont, Color.Black, textPosition);
    }

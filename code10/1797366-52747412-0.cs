    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        RectangleF drawArea = new RectangleF(offset.X, offset.Y, sprite.Width * zoom, sprite.Height * zoom);
        if (zoom >= 1)
        {
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
        }
        else
        {
            e.Graphics.InterpolationMode = InterpolationMode.Default;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Default;
        }
            
        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(31, 0, 0, 0)), drawArea);
        e.Graphics.DrawImage(sprite, drawArea);
    }

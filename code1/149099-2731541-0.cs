    Rectangle inner = new Rectangle(Point.Empty, ContentRectangle.Size);
    using (BufferedGraphics bg = BufferedGraphicsManager.Current.Allocate(e.Graphics, inner)) {
        using (Bitmap bmp = new Bitmap(inner.Width, inner.Height, bg.Graphics)) {
            using (Graphics bmpg = Graphics.FromImage(bmp)) {
                bg.Graphics.Clear(BackColor);
                do_my_drawing(bg.Graphics);
                bg.Graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                e.Graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                bmpg.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
    
                bg.Render(bmpg);
                e.Graphics.DrawImageUnscaledAndClipped(bmp, ContentRectangle);
            }
        }
    }

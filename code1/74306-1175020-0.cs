    Color c = Color.FromArgb(128, Color.Blue);
    using (Brush b = new SolidBrush(c))
    {
      e.Graphics.FillRectangle(b, 0, 0, 50, 50);
    }

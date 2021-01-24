    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
    Rectangle r = chart1.ClientRectangle;
    r.Inflate(-10, -10);
    using (SolidBrush brush = new SolidBrush(Color.FromArgb(55, Color.Beige)))
        e.Graphics.FillEllipse(brush, r);

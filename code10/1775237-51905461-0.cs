    using (var g = Graphics.FromHdc(m.WParam))
    {
        using (var e = new PaintEventArgs(g, ClientRectangle))
        {
            var r = new Rectangle(2, 12, Width - 4, Height - 2);
            using (var b = new LinearGradientBrush(r, BackColor, SystemColors.Window, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(b, r);//Draw the gradient.
            }
        }
    }

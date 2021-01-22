    int Top = bounds.Top;
    int Bottom = bounds.Bottom - 1;
    int Sign = 1;
    if (tabStrip.EffectiveOrientation == TabOrientation.Bottom)
    {
        Top = bounds.Bottom - 1;
        Bottom = bounds.Top;
        Sign = -1;
    }
    using (Pen OuterLightBorderPen = new Pen(SystemColors.ControlLightLight))
    {
        e.Graphics.DrawLine(OuterLightBorderPen, bounds.Left, Bottom, bounds.Left, Top + 2 * Sign);
        e.Graphics.DrawLine(OuterLightBorderPen, bounds.Left, Top + 2 * Sign, bounds.Left + 2, Top);
        e.Graphics.DrawLine(OuterLightBorderPen, bounds.Left + 2, Top, bounds.Right - 3, Top);
    }
    using (Pen InnerLightBorderPen = new Pen(SystemColors.ControlLight))
    {
        e.Graphics.DrawLine(InnerLightBorderPen, bounds.Left + 1, Bottom, bounds.Left + 1, Top + 2 * Sign);
        e.Graphics.DrawLine(InnerLightBorderPen, bounds.Left + 2, Top + 1 * Sign, bounds.Right - 3, Top + 1 * Sign);
    }
    using (Pen OuterDarkBorderPen = new Pen(SystemColors.ControlDarkDark))
    {
        e.Graphics.DrawLine(OuterDarkBorderPen, bounds.Right - 2, Top + 1 * Sign, bounds.Right - 1, Top + 2 * Sign);
        e.Graphics.DrawLine(OuterDarkBorderPen, bounds.Right - 1, Top + 2 * Sign, bounds.Right - 1, Bottom);
    }
    using (Pen InnerDarkBorderPen = new Pen(SystemColors.ControlDark))
        e.Graphics.DrawLine(InnerDarkBorderPen, bounds.Right - 2, Top + 2 * Sign, bounds.Right - 2, Bottom);

    Rectangle gradientRect = r;
    if (r.Width % 2 == 1)
    {
        gradientRect.Width += 1;
    }
    if (r.Height % 2 == 1)
    {
        gradientRect.Height += 1;
    }
    var lgb = new LinearGradientBrush(gradientRect, startCol, endCol, angle);
    graphics.FillRectangle(lgb, r);

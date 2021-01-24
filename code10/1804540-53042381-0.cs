    XGraphicsPath path = new XGraphicsPath();
    path.AddString("Clip!", new XFontFamily("Verdana"), XFontStyle.Bold, 90, 
        new XRect(0, 0, 250, 140), XStringFormats.Center);
 
    gfx.IntersectClip(path);
 
    // Draw a beam of dotted lines
    XPen pen = XPens.DarkRed.Clone();
    pen.DashStyle = XDashStyle.Dot;
    for (double r = 0; r <= 90; r += 0.5)
        gfx.DrawLine(pen, 0, 0, 
            250 * Math.Cos(r / 90 * Math.PI), 250 * Math.Sin(r / 90  Math.PI));

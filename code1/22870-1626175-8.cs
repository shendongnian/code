    Color original = Color.FromArgb(50, 120, 200);
    // original = {Name=ff3278c8, ARGB=(255, 50, 120, 200)}
    double hue;
    double saturation;
    double value;
    ColorToHSV(original, out hue, out saturation, out value);
    // hue        = 212.0
    // saturation = 0.75
    // value      = 0.78431372549019607
    Color copy = ColorFromHSV(hue, saturation, value);
    // copy = {Name=ff3278c8, ARGB=(255, 50, 120, 200)}
    // Compare that to the HSL values that the .NET framework provides: 
    original.GetHue();        // 212.0
    original.GetSaturation(); // 0.6
    original.GetBrightness(); // 0.490196079

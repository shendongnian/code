    string colorSpec = "#ff00ffff";
    byte alpha = byte.Parse(colorSpec.Substring(1,2), System.Globalization.NumberStyles.HexNumber);
    byte red = byte.Parse(colorSpec.Substring(3, 2),System.Globalization.NumberStyles.HexNumber);
    byte green = byte.Parse(colorSpec.Substring(5, 2), System.Globalization.NumberStyles.HexNumber);
    byte blue = byte.Parse(colorSpec.Substring(7, 2), System.Globalization.NumberStyles.HexNumber);
    Color fillColor = Color.FromArgb(alpha, red, green, blue);

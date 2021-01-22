    float[] colorValues = new float[4];
    colorValues[0] = c / 255f;
    colorValues[1] = m / 255f;
    colorValues[2] = y / 255f;
    colorValues[3] = k / 255f;
    System.Windows.Media.Color color = Color.FromValues(colorValues,
        new Uri(@"C:\Users\me\Documents\ISOcoated_v2_300_eci.icc"));
    System.Drawing.Color rgbColor = System.Drawing.Color.FromArgb(color.R, color.G, color.B);

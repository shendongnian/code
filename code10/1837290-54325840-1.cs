    public Color TemperatureRange(double value)
    {
        if (value < 0)
        {
            // blue range
            var max = new ColorRGB(Color.Blue);
            var color = ColorRGB.FromHSL(max.H, max.S * (-value), max.L);
            return Color.FromArgb(color.R, color.G, color.B);
        }
        else
        {
            // red range
            var max = new ColorRGB(Color.Red);
            var color = ColorRGB.FromHSL(max.H, max.S * value, max.L);
            return Color.FromArgb(color.R, color.G, color.B);
        }
    }

    public Color TemperatureRange(double value)
    {
        // start = blue = #0000FF
        // end = red = #FF0000
        // range [-1; 1]
        var r = (int)(0xff * (value + 1) / 2);
        var g = 0;
        var b = (int)(0xff * (1 - value) / 2);
        return Color.FromArgb(r, g, b);
    }

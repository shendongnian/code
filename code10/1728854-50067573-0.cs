    private static SolidColorBrush CreateColor()
    {
        var random = new Random();
        var r = Convert.ToByte(random.Next(0, 255));
        var g = Convert.ToByte(random.Next(0, 255));
        var b = Convert.ToByte(random.Next(0, 255));
        return new SolidColorBrush(Color.FromRgb(r, g, b));
    }

    public static Byte GetGreyValue(Byte red, Byte green, Byte blue)
    {
        Double redFactor = 0.2126d * Math.Pow(red, 2.2d);
        Double grnFactor = 0.7152d * Math.Pow(green, 2.2d);
        Double bluFactor = 0.0722d * Math.Pow(blue, 2.2d);
        Double grey = Math.Pow(redFactor + grnFactor + bluFactor, 1d / 2.2);
        return (Byte)Math.Max(0, Math.Min(255, Math.Round(grey, MidpointRounding.AwayFromZero)));
    }

    public static int ConvertColour(Color colour)
    {
        int r = colour.R;
        int g = colour.G * 256;
        int b = colour.B * 65536;
        return r + g + b;
    }

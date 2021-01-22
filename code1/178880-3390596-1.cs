    enum Color
    {
        red = 0,
        blue = 1
    }
    public Color GetColor(int v1, int v2)
    {
        int colorValue = v1 << 8;
        colorValue |= v2;
        return (Color)colorValue;
    }

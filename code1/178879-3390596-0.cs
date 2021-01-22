    enum Color
    {
        red = 0,
        blue = 1
    }
    public Color GetColor(int v1, int v2)
    {
        return ((Color)(v1+(4*v2)));
    }

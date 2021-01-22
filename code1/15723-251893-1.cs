    public Rectangle (Point start, int width, int height)
    {
        Start = start;
        Width = width;
        Height = height;
    }
    public Rectangle (int width, int height) :
        this (Point.Zero, width, height)
    {
    }

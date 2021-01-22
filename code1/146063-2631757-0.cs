    public Point BottomLeft
    {
        get { return new Point(Left, Bottom); }
        set { Location = new Point(value.X, value.Y - Height); }
    }

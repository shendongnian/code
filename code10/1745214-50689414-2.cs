    public Shape makeEllipse(string name)
    {
        Shape sh = new Ellipse
        {
            Name = name,
            Width = 100,
            Height = 80,
        };
        return sh;
    }

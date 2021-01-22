    public void PrintCoordinates(Point p)
    {
        p.GetCoordinates(out int x, out int y);
        WriteLine($"({x}, {y})");
    }
    public void PrintXCoordinate(Point p)
    {
        p.GetCoordinates(out int x, out _); // I only care about x
        WriteLine($"{x}");
    }

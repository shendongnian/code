    public void PrintCoordinates(Point p)
    {
      p.GetCoordinates(out int x, out int y);
      WriteLine($"({x}, {y})");
    }

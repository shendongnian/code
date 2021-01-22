    public void PrintCoordinates(Point p)
    {
      int x, y; // have to "predeclare"
      p.GetCoordinates(out x, out y);
      WriteLine($"({x}, {y})");
    }

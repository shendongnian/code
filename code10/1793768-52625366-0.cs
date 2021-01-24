    private static List<List<Point>> Test(int[][] Matrix, Point Position, List<List<Point>> Pos) {
      if (Position.Y < Matrix.Length && Position.X < Matrix[Position.Y].Length) {
        if (Similar(Matrix, new Point(Position.X, Position.Y), new Point(Position.X + 1, Position.Y))) {
          List<Point> List = Pos.LastOrDefault();
          if (List == null) List = new List<Point>();
    
          List.Add(new Point(Position.X, Position.Y));
          List.Add(new Point(Position.X + 1, Position.Y));
    
          Pos.Remove(Pos.LastOrDefault());
          Pos.Add(List.Distinct().ToList());
        } else Pos.Add(new List<Point>());
    
        return Test(Matrix, new Point(Position.X + 1, Position.Y), Pos);
      } else {
        if (Position.Y < Matrix.Length && Position.X == Matrix[Position.Y].Length)
          return Test(Matrix, new Point(0, Position.Y + 1), Pos);
      }
    
      return Pos.Where(Entity => Entity.Count > 0).ToList();
    }

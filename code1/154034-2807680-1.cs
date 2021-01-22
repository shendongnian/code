    class Path {
      public Path(IList<Point> points) {
        this.Points = new ReadOnlyCollection<Point>(points);
      }
      public ReadOnlyCollection<Point> Points {get;}
    }
    
    class RectanglePath : Path{
      public SquarePath (Point origin, int height, int width) : 
       base(new List<Point>{origin, new Point(origin.X + width, point.Y}, ....){
        
      }
    }

     public static class TupleExtensions
     {
          public static double Length( this Tuple<Point,Point> tuple )
          {
              var first = tuple.Item1;
              var second = tuple.Item2;
              double deltaX = first.X - second.X;
              double deltaY = first.y - second.Y;
              return Math.Sqrt( deltaX * deltaX + deltaY * deltaY );
          }
    }

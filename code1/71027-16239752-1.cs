      public class PointsAndLines
      {
        public static bool IsOutside(Point lineP1, Point lineP2, IEnumerable<Point> region)
        {
          if (region == null || !region.Any()) return true;
          var side = GetSide(lineP1, lineP2, region.First());
          return
            side == 0
            ? false
            : region.All(x => GetSide(lineP1, lineP2, x) == side);
        }
    
        public static int GetSide(Point lineP1, Point lineP2, Point queryP)
        {
          return Math.Sign((lineP2.X - lineP1.X) * (queryP.Y - lineP1.Y) - (lineP2.Y - lineP1.Y) * (queryP.X - lineP1.X));
        }
      }

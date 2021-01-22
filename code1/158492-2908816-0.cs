    public class Point {
      public override bool Equals (object other) {
        var otherPoint = other as Point;
    
        if (other == null)
          return false;
    
        //...
      }
    
      public static bool operator == (Point l, Point r) {
        //...
        //null checks
        if (!l.Equals(r))
          return false;
      }
    }

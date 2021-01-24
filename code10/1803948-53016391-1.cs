    var p1 = new Point
    {
      X = 1,
      Y = 2
    };
        
    var p2 = new Point
    {
      X = 2,
      Y = 3
    };
        
    float m = ((p2.y - p1.y) / (p2.x - p1.x));
    float n = m * p1.x - p1.y;
        
    var p3 = new Point
    {
      Y = 5
    };
    // result: P3's X is 6 in this scenario
    p3.X = (p3.Y - n) / m;
    public class Point
    {
      public float X { get; set; }
      public float Y { get; set; }
    }

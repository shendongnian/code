    public interface ISolid{
      double Volume { get; }
    }
    
    public class Cylinder: ISolid{
      public double Height { get; set; }
      public double Radius { get; set; }
      public double Volume {
        get
        {
          return (2 * Math.Pi * Radius ^ 2) * Height;
        }
      }
    }
    
    public class Cube: ISolid{
      public double Width { get; set; }
      public double Height { get; set; }
      public double Depth { get; set; }
      public double Volume {
        get
        {
          return Width * Height * Depth;
        }
      }
    }

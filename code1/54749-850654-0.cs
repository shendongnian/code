    // Non mutable Angle class with a normalized, integer angle-value
    public struct Angle
    {
      public Angle(int value)
      {
        Value = value;
      } 
      private angle;
      public Value 
      { 
        get { return angle; } 
        private set { angle = Normalize(value); } 
      }
      public static int Normalize(int value)
      {
         if (value < 0) return 360 - (value % 360);
         return value % 360;
      }
    }
    public class SomeClass
    {
      public Angle EyeOrientation { get; set; }
    }

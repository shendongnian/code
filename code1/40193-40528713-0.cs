    public class Colors: IClonable
    {
      public int Red;
      public int Green;
      public int Blue;
    
      public object Clone()
      {
        return this.MemberwiseClone();
      }
    }

    public class SodaCan: BeverageHolder
    {
      public SodaCan(string brand)
      {
        Brand = brand;
        IsFull = true;
        Dimensions = new Cylinder { Height = 5D, Radius = 1.5D };
      }
    
      private ISolid Dimensions { get; set; }
      
      public double Volume {
        get {
          return Dimensions.Volume;
        }
      }
    }

    public class SodaCan: Cylinder
    {
      public SodaCan(string brand)
      {
        Brand = brand;
        IsFull = true;
        Height = 5D;
        Radius = 1.5D;
      }
    
      public string Brand { get; private set; }
      public bool IsFull { get; set; }
    }

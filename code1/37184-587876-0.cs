    public sealed class Shape {
      private readonly Func<int> areaFunction;
      public Shape(Func<int> areaFunction) { this.areaFunction = areaFunction; }
  
      public int Area { get { return areaFunction(); } }
    }

    public class ReadOnlyPoint {
      public int X { get; private set; }
      public int Y { get; private set; }
      public ReadOnlyPoint(int x, int y) { X = x; Y = y; }
    }

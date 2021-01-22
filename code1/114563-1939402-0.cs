    public class Coordinate : IEquatable<Coordinate>
    {
         public Coordinate(int x, int y);
         public int X { get; }
         public int Y { get; }
         // override Equals and GetHashcode...
    }

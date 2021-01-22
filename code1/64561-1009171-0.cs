    public class Location3D
    {
      public Location3D(int x, int y, int z) { X = x; Y = y; Z = z; }
      public int X { get; set; }
      public int Y { get; set; }
      public int Z { get; set; }
    }
    
    public abstract GamePiece
    {
      public Location3d { get; set; }
    
    public class Person: GamePiece // inherit GamePiece
    {
      // everything else about Person
    }
    
    public class Board
    {
      public Board()
      {
        person = new Person(this);
        rnd = new Random();
        gameBoard = new Cube[10, 10, 10];
        gameBoard.Initialize();
        int xAxis = rnd.Next(11);
        int yAxis = rnd.Next(11);
        int zAxis = rnd.Next(11);
    
        var location = new Location3D(xAxis, yAxis, zAxis);
        person.Location = location;
    
        GetCubeAt(location).AddContents(person);
      }
    
      public Cube GetCubeAt(Location3D location)
      {
        return gameBoard[location.X, location.Y, location.Z];
      }
    
      public Cube GetCubeAt(int x, int y, int z)
      {
        return GetCubeAt(new Location3D(x,y,z));
      }
    }

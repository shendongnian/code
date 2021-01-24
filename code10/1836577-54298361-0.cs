    public class Tile
    {
        public int ceiling { get; set; }
        public int northWall { get; set; }
        public int westWall { get; set; }
        public int floor { get; set; }
    
        public Tile(int c, int n, int w, int f)
        {
            ceiling = c;
            northWall = n;
            westWall = w;
            floor = f;
        }
    }

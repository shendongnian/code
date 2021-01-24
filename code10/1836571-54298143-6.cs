    [System.Serializable]
    public class Tile
    {
        // use fieldsinstead of properties
        public int Ceiling ;
        public int NorthWall;
        public int WestWall;
        public int Floor;
    
        public Tile(int ceiling, int northWall, int westWall, int floor)
        {
            Ceiling = ceiling;
            NorthWall = northWall;
            WestWall = westWall;
            Floor = floor;
        }
    }

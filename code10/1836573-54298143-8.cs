    // use this tag to make it 
    // serializable and e.g. visiable in the inspector
    [System.Serializable]
    public class Tile
    {
        // use fields instead of properties 
        // since also properties are not serialzed
        public int ceiling;
        public int northWall;
        public int westWall;
        public int floor;
    }

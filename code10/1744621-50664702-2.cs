    public static class DataStorage
    {
        public static HashSet<Coordinate> WayPoints { get; }
        static DataStorage()
        {
            WayPoints = new HashSet<Coordinate>()
        }
    }

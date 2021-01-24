    public static class DataStorage
    {
        public static HashSet<Coordinate> WayPoints { get; }
        static DataStorage()
        {
            WayPoints = new HashSet<Coordinate>();
        }
        public static Coordinate? GetCoordinateOrDefault(string latitude, string longitude)
        {
            var coordinate = new Coordinate(latitude, longitude);
            return WayPoints.Contains(coordinate) ? (Coordinate?)coordinate : null;
        } 
    }

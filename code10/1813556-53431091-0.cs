    public class Location : IModule
    {
        public string Id { get; set; }
        public Coordinate Coordinate { get; set; }
    }
    [Owned]
    public class Coordinate
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

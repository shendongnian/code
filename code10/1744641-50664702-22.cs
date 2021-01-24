    public struct Coordinate
    {
        public string Latitude  { get; } 
        public string Longitude { get; }
        public Coordinate(string latitude, string longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
    }

    public stuct Coordinate
    {
        public string Latitude  { get; set; } 
        public string Longitude { get; set; }
        public Coordinate(string latitude, string longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
    }

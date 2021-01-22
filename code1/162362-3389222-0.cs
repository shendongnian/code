    public class GoogleGeoCodeResponse
    {
        public string status { get; set; }
        public results[] results { get; set; }
    
    }
    public class results
    {
        public string formatted_address { get; set; }
        public geometry geometry { get; set; }
    }
    public class geometry
    {
        public string location_type { get; set; }
        public location location { get; set; }
    }
    public class location
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }
